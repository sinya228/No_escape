using Leopotam.Ecs;

sealed class CritMultiplierMerregeSystem : IEcsRunSystem
{
  

    public void Run()
    {

        /*foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);

            foreach (var j in CritMultiplierFilter)
            {

                ref var critmultiplierstat = ref CritMultiplierFilter.Get1(j);

                if (allstats.Index == critmultiplierstat.StatsIndex)
                {
                    StatSum += critmultiplierstat.CritMultiplier;                   
                }

            }

            AllStatsFilter.GetEntity(i).Get<CritMultiplierComponent>().CritMultiplier = StatSum;

        }*/

    }

}