using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Physics;

[BurstCompile]
[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public partial struct WalkSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnStartRunning(ref SystemState state)
    {

    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
           
        var job = new WalkJob
        {
            deltaTime = SystemAPI.Time.DeltaTime
        };

        job.Schedule();
    }
}


[BurstCompile]
public partial struct WalkJob : IJobEntity
{
    public float deltaTime;

    void Execute(Entity e, ref Walk walk, ref LocalTransform transform, ref Turn turn, ref PhysicsVelocity velocity)
    {
        if (!walk.isMoving) return;

        if (turn.canTurn)
        {
            float3 dir = math.normalize(walk.targetPosition - transform.Position);
                quaternion currR = transform.Rotation;
                quaternion targetR = quaternion.LookRotationSafe(dir, math.up());

                quaternion newRotation = math.slerp(currR, targetR, turn.turnRate * deltaTime);
                transform.Rotation = newRotation;
        }

        
        float3 target = walk.targetPosition;
        target.y = transform.Position.y;
        float3 difference = target - transform.Position;
        float distancesq = math.dot(difference, difference);
        //hasn't reached yet
        if (distancesq > 0.01f) {
            walk.isMoving = true;
            float3 direction = math.normalize(difference);
            velocity.Linear = direction * walk.moveSpeed;
            return;
        }
        else
        {
            walk.isMoving = false;
  
        }
    }
}

