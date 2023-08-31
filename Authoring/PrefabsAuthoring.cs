using Unity.Entities;
using UnityEngine;

public class TMPauthoring: MonoBehaviour
{
    public GameObject textPrefab;
    public float textPrefabLifeTime;
    //public GameObject canvasRef;
    public class Baker : Baker<TMPauthoring>
    {
        public override void Bake(TMPauthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            //AddComponent<TextComp>(entity);
            TextComp textGO = new TextComp();
            textGO.textPrefabLifeTime = authoring.textPrefabLifeTime;
            textGO.textPrefab = authoring.textPrefab;
            AddComponentObject(entity ,textGO);
           

            //CanvasComp canvasGO = new CanvasComp();
            //canvasGO.canvasRef = authoring.canvasRef;
            //AddComponentObject(entity, canvasGO);
        }
    }
}
public class TextComp : IComponentData
{
    public GameObject textPrefab;
    public float textPrefabLifeTime;
}

//public class CanvasComp : IComponentData
//{
//    public GameObject canvasRef;
//}
