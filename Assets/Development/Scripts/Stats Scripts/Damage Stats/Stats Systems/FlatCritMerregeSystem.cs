using Leopotam.Ecs;

sealed class FlatCritMerregeSystem : IEcsRunSystem
{
    private readonly EcsFilter<FlatCritComponent>.Exclude<AllStatsComponent> FlatCritFilter = null;

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    public void Run()
    {

        foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);

            ref var entity = ref AllStatsFilter.GetEntity(i);



            foreach (var j in FlatCritFilter)
            {

                ref var flatcritstat = ref FlatCritFilter.Get1(j);

                if (allstats.Index == flatcritstat.StatsIndex)
                {
                    StatSum += flatcritstat.FlatCrit;
                    entity.Get<FlatCritComponent>().FlatCrit= StatSum;
                }

            }

       

        }

    }

}
