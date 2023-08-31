//using System;
//using Unity.Entities;
//using Unity.Mathematics;
//using Unity.Transforms;
//using UnityEngine;

//public partial class DisplayPositionSystem : SystemBase
//{

//    private EntityCommandBuffer ecb;
//    private EntityManager manager;
//    private EntityQuery singleton_query;
//    protected override void OnStartRunning()
//    {
//        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
//        singleton_query = manager.CreateEntityQuery(typeof(TextComp));
//    }

//    protected override void OnUpdate()
//    {

//        Entity singleton = singleton_query.GetSingletonEntity();
//        //TextComp textComp = singleton_query.GetSingleton<TextComp>();
//        TextComp textComp = SystemAPI.GetComponentRO<TextComp>(singleton);
//        ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
//        foreach ((RefRO<LocalTransform> transform, RefRO<RandomWalk> rw, Entity e) in SystemAPI.Query<RefRO<LocalTransform>, RefRO<RandomWalk>>().WithEntityAccess())
//        {
//            if (rw.ValueRO.randomWalkTimer <= 0)
//            {
//                //OnMove?.Invoke(transform.ValueRO.Position, e);
//                ecb.AddComponent(e, new FollowMoveTag { });
//                GameObject txt  = UnityEngine.Object.Instantiate(textComp.textPrefab);
//                ecb.AddComponent(e, new TextComp { textPrefab = txt});
                
//            }
//        }
//        ecb.Playback(EntityManager);
//        ecb.Dispose();


//    }
//}

//public partial class FollowMoveSystem : SystemBase
//{
//    public Action<float3> OnMove;
//    //EntityCommandBuffer ecb;
//    protected override void OnStartRunning()
//    {
//        //ecb = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
//    }
//    protected override void OnUpdate()
//    {
//        foreach( (RefRO<FollowMoveTag> tag, RefRO<LocalTransform> transform) in SystemAPI.Query<RefRO<FollowMoveTag>, RefRO<LocalTransform> >())  {
//           // OnMove?.Invoke(transform.ValueRO.Position);
            
//        }
//    }
//}

//public struct FollowMoveTag : IComponentData
//{

//}

