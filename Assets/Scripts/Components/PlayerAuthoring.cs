using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct Player : IComponentData
{

}

public struct ClosestEnemy : IComponentData
{
    public Entity entity;
    public float3 position;
}

public class PlayerAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Player());
        dstManager.AddComponentData(entity, new ClosestEnemy());
    }
}