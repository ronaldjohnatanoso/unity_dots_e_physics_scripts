//using JetBrains.Annotations;
//using TMPro;
//using Unity.Entities;
//using Unity.Mathematics;
//using Unity.Transforms;
//using UnityEngine;

//public class WorldUIController : MonoBehaviour
//{
//    public TextMeshProUGUI textUI;
//    private float3 pos;
//    FollowMoveSystem inputSystem;


//    void OnEnable()
//    {
//        inputSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<FollowMoveSystem>();
//        inputSystem.OnMove += DisplayPosition;

//    }

//    void OnDisable()
//    {

//        inputSystem.OnMove -= DisplayPosition;
//    }

//    private void Update()
//    {


//    }

//    void FollowDisplayPosition(float3 pos, Entity e)
//    {

//    }

//    void DisplayPosition(float3 position)
//    {
//        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
//        //var eLocalTransform = entityManager.GetComponentData<LocalTransform>(e);
//        //var ePosition = eLocalTransform.Position;
//        var obj = Instantiate(textUI);
//        obj.transform.SetParent(transform, false);
//        //obj.transform.position = ePosition;
//        textUI.SetText("Pos: " + position.ToString());

//        Destroy(obj, 2f);
//    }

//    //private System.Collections.IEnumerator DisplayAndHidePosition(float3 position)
//    //{
//    //    var obj = Instantiate(textUI);
//    //    obj.transform.parent = transform;
//    //    obj.transform.position = position;
//    //    textUI.SetText("Pos: " + position.ToString());
//    //    textUI.transform.position = position;

//    //    // Wait for 2 seconds
//    //    yield return new WaitForSeconds(2f);

//    //    // After 2 seconds, clear the text
//    //    textUI.SetText("");
//    //}
//}
