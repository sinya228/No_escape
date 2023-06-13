using Leopotam.Ecs;

sealed class CritMultiplierMerregeSystem : IEcsRunSystem
{
    private readonly EcsFilter<CritMultiplierComponent>.Exclude<AllStatsComponent> CritMultiplierFilter = null;

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    public void Run()
    {

        foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);

            ref var entity = ref AllStatsFilter.GetEntity(i);



            foreach (var j in CritMultiplierFilter)
            {

                ref var critmultiplierstat = ref CritMultiplierFilter.Get1(j);

                if (allstats.Index == critmultiplierstat.StatsIndex)
                {
                    StatSum += critmultiplierstat.CritMultiplier;
                    entity.Get<CritMultiplierComponent>().CritMultiplier = StatSum;
                }

            }


        }

    }

}