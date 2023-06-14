using Leopotam.Ecs;

sealed class FlatCritMerregeSystem : IEcsRunSystem
{
    

    public void Run()
    {

        /*foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);

            foreach (var j in FlatCritFilter)
            {

                ref var flatcritstat = ref FlatCritFilter.Get1(j);

                if (allstats.Index == flatcritstat.StatsIndex)
                {
                    StatSum += flatcritstat.FlatCrit;
                  
                }

            }

            AllStatsFilter.GetEntity(i).Get<FlatCritComponent>().FlatCrit = StatSum;

        }*/

    }

}
