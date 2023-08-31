
using Unity.Entities;
using Unity.Mathematics;


public struct Walk : IComponentData
{
    public float moveSpeed;
    public float3 targetPosition;
    public bool isMoving;
}