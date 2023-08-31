using System.ComponentModel;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Extensions;
using Unity.Physics.Systems;
using UnityEngine;

[BurstCompile]
//[UpdateInGroup(typeof(PhysicsSystemGroup))]
//[UpdateAfter(typeof(PhysicsSimulationGroup))]
public partial struct TestCollisionSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SimulationSingleton>();
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Dependency = new CollisionJob() { 
            VelocityLookup = SystemAPI.GetComponentLookup<PhysicsVelocity>(true)
        }.Schedule(SystemAPI.GetSingleton<SimulationSingleton>(), state.Dependency);

        //DisableGroundCollision();
    }

    //[BurstCompile]
    //private void DisableGroundCollision()
    //{
    //    PhysicsWorldSingleton physicsWorldSingleton = SystemAPI.GetSingleton<PhysicsWorldSingleton>();
    //    PhysicsWorld world = physicsWorldSingleton.PhysicsWorld;
    //    CollisionWorld collisionWorld = physicsWorldSingleton.CollisionWorld;
    //    CollisionFilter filter = new CollisionFilter { 
    //        BelongsTo = 1,
    //        CollidesWith = ~0u,
    //        GroupIndex = 0
    //    };
    //    collisionWorld
    //   // CollisionFilter groundFilter =
    //}

    [BurstCompile]
    private struct CollisionJob : ICollisionEventsJob
    {
         [Unity.Collections.ReadOnly] public ComponentLookup<PhysicsVelocity> VelocityLookup;
        public void Execute(CollisionEvent collisionEvent)
        {
      
            Entity entityA = collisionEvent.EntityA;
            Entity entityB = collisionEvent.EntityB;

           // Debug.Log("bump?");
        }
    }
}


// Debug.Log($"A: {collisionEvent.EntityA}, B: {collisionEvent.EntityB}");


       
