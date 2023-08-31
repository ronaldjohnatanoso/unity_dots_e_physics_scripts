using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class WalkAuthoring : MonoBehaviour
{
    public float moveSpeed;
    public float3 targetPosition;
    public bool isMoving;

    public class Baker : Baker<WalkAuthoring>
    {
        public override void Bake(WalkAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Walk
            {
                moveSpeed = authoring.moveSpeed,
                targetPosition = authoring.targetPosition,
                isMoving = authoring.isMoving
            });
        }
    }
}