using JetBrains.Annotations;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Random = Unity.Mathematics.Random;

[BurstCompile]
public partial struct BeanSpawner : ISystem
{
    [BurstCompile]
    public void Oncreate(ref SystemState state)
    {
        state.RequireForUpdate<EnvConfig>();
        state.RequireForUpdate<BeginInitializationEntityCommandBufferSystem>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
        var ecb = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
       // var env = SystemAPI.GetSingleton<EnvConfig>();

        if (SystemAPI.TryGetSingleton<EnvConfig>(out var env) && env.InitialBeansToSpawn > 0)
        {
            for (int i = 0; i < env.InitialBeansToSpawn; i++)
            {
                new InitialSpawnJob
                {
                    k = 0,
                    ECB = ecb.CreateCommandBuffer(state.WorldUnmanaged)
                }.Schedule();
            }
            state.Enabled = false;
        }

        float deltaTime = SystemAPI.Time.DeltaTime;
        new IntervalSpawnJob
        {
            k = 0,
            ECB = ecb.CreateCommandBuffer(state.WorldUnmanaged),
            deltaTime = deltaTime,
        }.Schedule();
        
    }
}

[BurstCompile]
public partial struct IntervalSpawnJob : IJobEntity
{
    public  EntityCommandBuffer ECB;
    public int k;
    public float deltaTime;

    void Execute(ref EnvConfig env, in LocalTransform transform)
    {
        env.BeanSpawnTimer -= deltaTime;
        if (env.BeanSpawnTimer > 0) return;
        Entity entity =  ECB.Instantiate( env.BeanPrefab);
        ECB.SetComponent( entity, transform);
        ECB.SetComponent( entity, new RandomWalk
        {
            ENTITY_RANDOM = Random.CreateFromIndex((uint)entity.Index + (uint)entity.Version),
            randomWalkPosition = new float3(0, 0, 0),
            randomWalkTimer = 0,
            randomWalkTimer_Maximum = 3f,
            randomWalkTimer_Minimum = 10f
        } );
        env.BeanSpawnTimer = env.BeanSpawnInterval;
    }
  
        
    
}

[BurstCompile]
public partial struct InitialSpawnJob : IJobEntity
{
    public EntityCommandBuffer ECB;
    public int k;
    void Execute(ref EnvConfig env, in LocalTransform transform)
    {

        var e = ECB.Instantiate( env.BeanPrefab);
        float halfX = env.FieldDimension.x / 2;
        float halfZ = env.FieldDimension.y / 2;

        ECB.SetComponent(e, new LocalTransform {
            Position = new Unity.Mathematics.float3(
                env.randomValue.NextFloat(-(halfX), halfX),
                transform.Position.y,
                env.randomValue.NextFloat(-(halfZ), halfZ)),
            Rotation = quaternion.identity,
            Scale = 1f
        });
        ECB.SetComponent(e, new RandomWalk
        {
            ENTITY_RANDOM = Random.CreateFromIndex((uint)e.Index + (uint)e.Version),
            randomWalkPosition = new float3(0, 0, 0),
            randomWalkTimer = 0,
            randomWalkTimer_Maximum = 3f,
            randomWalkTimer_Minimum = 10f
        });



    }
}


