using Unity.Entities;
using Unity.Mathematics;
public struct RandomWalk : IComponentData
{
    public float3 randomWalkPosition;
    public float randomWalkTimer;
    public float randomWalkTimer_Minimum;
    public float randomWalkTimer_Maximum;

    public Random ENTITY_RANDOM;
}