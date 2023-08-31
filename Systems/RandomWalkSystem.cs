using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;

[BurstCompile]
public partial struct RandomWalkSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<EnvConfig>();
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EnvConfig env = SystemAPI.GetSingleton<EnvConfig>();
        float deltaTime = SystemAPI.Time.DeltaTime;
        var job = new RandomWalkJob
        {
            deltaTime = deltaTime,
            envConfig = env,
        };

        job.Schedule();
    }



    //[BurstCompile]
    //public void OnStartRunning(ref SystemState state)
    //{
    //    //foreach (var (randomWalk, e) in SystemAPI.Query<RefRW<RandomWalk>>().WithEntityAccess())
    //    //{
    //    //    randomWalk.ValueRW.ENTITY_RANDOM = Random.CreateFromIndex((uint)e.Index + (uint)e.Version);

    //    //}
    //}


    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }

}

[BurstCompile]
public partial struct RandomWalkJob : IJobEntity
{

    public EnvConfig envConfig;
    public float deltaTime;


    void Execute(ref Walk walk, ref RandomWalk randomWalk, ref LocalTransform transform)
    {

        if (randomWalk.randomWalkTimer > 0)
        {
            randomWalk.randomWalkTimer -= deltaTime;
        }
        else if (randomWalk.randomWalkTimer <= 0)
        {

            // Set the timer to a new random starting point
            randomWalk.randomWalkTimer = randomWalk.ENTITY_RANDOM.NextFloat(randomWalk.randomWalkTimer_Minimum, randomWalk.randomWalkTimer_Maximum);

            // Set a new random target position for the walk component
            float halfX = envConfig.FieldDimension.x / 2;
            float halfZ = envConfig.FieldDimension.y / 2;

            walk.targetPosition = new Unity.Mathematics.float3(
                randomWalk.ENTITY_RANDOM.NextFloat(-(halfX), halfX),
                transform.Position.y,
                randomWalk.ENTITY_RANDOM.NextFloat(-(halfZ), halfZ)
                );
            walk.isMoving = true;
        }
    }

}
