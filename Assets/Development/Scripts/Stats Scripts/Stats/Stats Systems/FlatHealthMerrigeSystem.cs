using Leopotam.Ecs;
using UnityEngine;


sealed class FlatHealthMerrigeSystem : IEcsRunSystem
{
    private readonly EcsFilter<FlatHealthComponent>.Exclude<AllStatsComponent> FlatHealthFilter = null;

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    public void Run()
    {

        foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);

            ref var entity = ref AllStatsFilter.GetEntity(i);



            foreach (var j in FlatHealthFilter)
            {

                ref var flathealthstat = ref FlatHealthFilter.Get1(j);

                if (allstats.Index == flathealthstat.StatsIndex)
                {
                    StatSum += flathealthstat.FlatHealth;
                    entity.Get<FlatHealthComponent>().FlatHealth = StatSum;
                }

            }       

        }

    }

}