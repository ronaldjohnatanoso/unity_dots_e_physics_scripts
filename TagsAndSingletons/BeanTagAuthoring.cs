using Unity.Entities;
using UnityEngine;

public class BeanTagAuthoring : MonoBehaviour
{
    public class Baker : Baker<BeanTagAuthoring>
    {
        public override void Bake(BeanTagAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new BeanTag
            {
            
            });
        }
    }
}

public struct BeanTag : IComponentData
{

}