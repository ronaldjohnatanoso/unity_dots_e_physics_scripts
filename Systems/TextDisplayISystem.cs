//using Unity.Entities;
//using UnityEngine;
//using Unity.Transforms;
//using Unity.Mathematics;
//using TMPro;
//using Unity.Burst;

//[BurstCompile]
//public partial struct FollowTextDisplayISystem : ISystem
//{

//    public void OnUpdate(ref SystemState state)
//    {
//        float delta = SystemAPI.Time.DeltaTime;
//        foreach ((TextComp textComp, RefRO<LocalTransform> transform) in SystemAPI.Query<TextComp, RefRO<LocalTransform>>().WithNone<EnvConfig>())
//        {
//            //caching and not removing the component
//            if (textComp.textPrefab == null)
//            {
//                continue;
//            }
//            else if (textComp.textPrefabLifeTime <= 0)
//            {
//                GameObject.Destroy(textComp.textPrefab);
//                continue;
//            }


//            textComp.textPrefabLifeTime -= delta;
//            //  textComp.textPrefab.transform.position = transform.ValueRO.Position;

//            textComp.textPrefab.transform.position = transform.ValueRO.Position;
//            //Debug.Log(textComp.textPrefab.transform.position + " and " + transform.ValueRO.Position);
//            //Debug.Break();

//        }
//    }
//}
//public partial class TextDisplayISystem : SystemBase
//{
//    private GameObject canvas;
//    private Entity env;
//    private TextComp txtComp;
//    private GameObject GO;
//    private TextComp entityTextComp;
//    private EntityCommandBuffer ecb;

//    protected override void OnCreate()
//    {
//        RequireForUpdate(GetEntityQuery(ComponentType.ReadOnly<EnvConfig>()));
//    }

//    protected override void OnStartRunning()
//    {
//        canvas = GameObject.FindGameObjectWithTag("Canvas");
//        env = SystemAPI.GetSingletonEntity<EnvConfig>();
//        txtComp = SystemAPI.ManagedAPI.GetComponent<TextComp>(env);
//        //  ecb = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(EntityManager.WorldUnmanaged);

//    }
//    protected override void OnUpdate()
//    {
//        ecb = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(EntityManager.WorldUnmanaged);


//        foreach ((RefRO<RandomWalk> rw, RefRO<LocalTransform> LocalTransform, Entity e) in SystemAPI.Query<RefRO<RandomWalk>, RefRO<LocalTransform>>().WithEntityAccess())
//        {
//            if (rw.ValueRO.randomWalkTimer <= 0)
//            {
//                //GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
//                // if (canvas == null) Debug.Log("no canvas");

//                // var env = SystemAPI.GetSingletonEntity<EnvConfig>();
//                // TextComp txtComp = SystemAPI.ManagedAPI.GetComponent<TextComp>(env);

//                GO = GameObject.Instantiate(txtComp.textPrefab, LocalTransform.ValueRO.Position, quaternion.identity);

//                entityTextComp = new TextComp();
//                entityTextComp.textPrefab = GO;
//                entityTextComp.textPrefab.transform.SetParent(canvas.transform);

//                //test

//                entityTextComp.textPrefabLifeTime = txtComp.textPrefabLifeTime;
//                TextMeshProUGUI temp = entityTextComp.textPrefab.GetComponent<TextMeshProUGUI>();
//                temp.SetText("" + entityTextComp.textPrefab.transform.position);
//                //var ecb = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
//                ecb.AddComponent(e, entityTextComp); //added TextComp 

//            }


//        }

//    }

//}




