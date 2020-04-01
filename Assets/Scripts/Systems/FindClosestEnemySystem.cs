using EntitiesBT.Entities;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(VirtualMachineSystem))]
public class FindClosestEnemySystem : SystemBase
{
    EndSimulationEntityCommandBufferSystem m_EndSimulationEcbSystem;

    EntityQuery m_enemyQuery;

    struct EnemyInfo
    {
        public Entity entity;
        public float3 position;
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        m_EndSimulationEcbSystem = World
            .GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        m_enemyQuery = GetEntityQuery(
            ComponentType.ReadOnly<Enemy>(),
            ComponentType.ReadOnly<Translation>()
            );
    }

    protected override void OnUpdate()
    {
        int enemyCount = m_enemyQuery.CalculateEntityCount();
        if (enemyCount == 0)
        {
            return;
        }

        var ecb = m_EndSimulationEcbSystem.CreateCommandBuffer().ToConcurrent();

        var enemies = new NativeArray<EnemyInfo>(enemyCount, Allocator.TempJob);

        // Get all Enemies
        Entities
            .WithStoreEntityQueryInField(ref m_enemyQuery)
            .ForEach((Entity entity,
                int entityInQueryIndex,
                ref Enemy enm,
                ref Translation trans) =>
            {
                enemies[entityInQueryIndex] = new EnemyInfo { 
                    entity = entity,
                    position = trans.Value
                };
            })
            .Schedule();

        // Set enemy infor to player
        Entities
            .ForEach((Entity entity,
                      int entityInQueryIndex,
                      ref ClosestEnemy closestEnemy,
                      in Translation trans,
                      in Player player) =>
            {
                float sqMinDistance = float.MaxValue;
                foreach (var enemy in enemies)
                {
                    if ( math.lengthsq( trans.Value - enemy.position ) < sqMinDistance )
                    {
                        closestEnemy.entity = enemy.entity;
                        closestEnemy.position = enemy.position;
                    }
                }
            })
            .WithDeallocateOnJobCompletion(enemies)
            .ScheduleParallel();
    }
}
