using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RandomWalkAuthoring : MonoBehaviour
{
    public float randomWalkTimer;
   // public float3 randomWalkPosition;
    public float randomWalkTimer_Minimum;
    public float randomWalkTimer_Maximum;

    public uint ENTITY_RANDOM;
    public class Baker : Baker<RandomWalkAuthoring>
    {
        public override void Bake(RandomWalkAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RandomWalk
            {
                randomWalkTimer = authoring.randomWalkTimer,
                //randomWalkPosition =  authoring.randomWalkPosition,
                randomWalkTimer_Maximum = authoring.randomWalkTimer_Maximum,
                randomWalkTimer_Minimum = authoring.randomWalkTimer_Minimum,
                ENTITY_RANDOM = Random.CreateFromIndex( (uint)entity.Version + (uint)entity.Index )
            });
        }
    }
}