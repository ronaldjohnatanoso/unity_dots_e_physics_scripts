using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;



public class EnvConfigAuthoring : MonoBehaviour
{
    public uint Seed;
    public float2 FieldDimension;
    public GameObject BeanPrefab;
    public int InitialBeansToSpawn;

    public float BeanSpawnInterval;
    public float BeanSpawnTimer;

    public int Value;

    public class EnvConfigBaker : Baker<EnvConfigAuthoring>
    {
        public override void Bake(EnvConfigAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new EnvConfig
            {
                randomValue = Unity.Mathematics.Random.CreateFromIndex(authoring.Seed),
                FieldDimension = authoring.FieldDimension,
                BeanPrefab = GetEntity(authoring.BeanPrefab, TransformUsageFlags.Dynamic),
                InitialBeansToSpawn = authoring.InitialBeansToSpawn,
                BeanSpawnInterval = authoring.BeanSpawnInterval,
                BeanSpawnTimer = authoring.BeanSpawnTimer,
                
            }) ;

            AddComponent(entity, new OneInteger
            {
                Value = authoring.Value
            });
        }
    }
}

public struct EnvConfig : IComponentData
{
    public Unity.Mathematics.Random randomValue;
    public float2 FieldDimension;
    public Entity BeanPrefab;
    public int InitialBeansToSpawn;

    public float BeanSpawnInterval;
    public float BeanSpawnTimer;

}

public struct OneInteger : IComponentData
{
    public int Value;
}