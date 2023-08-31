using Unity.Entities;

public struct Turn : IComponentData
{
    public float turnRate;
    public bool canTurn;
}