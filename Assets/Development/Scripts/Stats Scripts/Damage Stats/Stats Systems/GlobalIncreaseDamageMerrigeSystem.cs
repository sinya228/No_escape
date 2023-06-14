using Leopotam.Ecs;

sealed class GlobalIncreaseDamageMerrigeSystem : IEcsRunSystem
{
 

    public void Run()
    {

        /*foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);

            foreach (var j in IncreaseDamageFilter)
            {

                ref var increasedamagestat = ref IncreaseDamageFilter.Get1(j);

                if (allstats.Index == increasedamagestat.StatsIndex)
                {
                    StatSum += increasedamagestat.IncreaseDamage;               
                }

            }

            AllStatsFilter.GetEntity(i).Get<GlobalIncreaseDamageComponent>().IncreaseDamage = StatSum;

        }*/

    }

}
