using Leopotam.Ecs;

sealed class GlobalIncreaseDamageMerrigeSystem : IEcsRunSystem
{
    private readonly EcsFilter<GlobalIncreaseDamageComponent>.Exclude<AllStatsComponent> IncreaseDamageFilter = null;

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    public void Run()
    {

        foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);

            ref var entity = ref AllStatsFilter.GetEntity(i);



            foreach (var j in IncreaseDamageFilter)
            {

                ref var increasedamagestat = ref IncreaseDamageFilter.Get1(j);

                if (allstats.Index == increasedamagestat.StatsIndex)
                {
                    StatSum += increasedamagestat.IncreaseDamage;
                    entity.Get<GlobalIncreaseDamageComponent>().IncreaseDamage = StatSum;
                }

            }

          

        }

    }

}
