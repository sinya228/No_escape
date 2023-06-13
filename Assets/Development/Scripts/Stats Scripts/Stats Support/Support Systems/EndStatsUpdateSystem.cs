using Leopotam.Ecs;
using UnityEngine;

public class EndStatsUpdateSystem : IEcsRunSystem
{
    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;
    public void Run()
    {
        foreach (var i in AllStatsFilter)
        {
            ref var entity = ref AllStatsFilter.GetEntity(i);
            entity.Del<StatsUpdateEvent>();
        }
    }

}
