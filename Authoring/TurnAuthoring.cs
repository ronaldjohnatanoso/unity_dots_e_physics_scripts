using UnityEngine;
using Unity.Entities;
public class TurnAuthoring : MonoBehaviour
{
    public float turnRate;
    public bool canTurn;

    public class Baker : Baker<TurnAuthoring>
    {
        public override void Bake(TurnAuthoring authoring)
        {
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), new Turn
            {
                turnRate = authoring.turnRate,
                canTurn = authoring.canTurn,
            });
        }
    }
}