using Leopotam.Ecs;

sealed class PhysicalFlatDamageMerregeSystem : IEcsRunSystem
{
    private readonly EcsFilter<PhysicalFlatDamageComponent>.Exclude<AllStatsComponent> FlatDamageFilter = null;

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    public void Run()
    {
    
        foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;
          
            ref var allstats = ref AllStatsFilter.Get1(i);
            
            ref var entity = ref AllStatsFilter.GetEntity(i);

           

            foreach (var j in FlatDamageFilter)
            {

                ref var flatdamagestat = ref FlatDamageFilter.Get1(j);

                if (allstats.Index == flatdamagestat.StatsIndex) 
                {
                    StatSum += flatdamagestat.FlatDamage;
                    entity.Get<PhysicalFlatDamageComponent>().FlatDamage = StatSum;
                }

            }

        }
        
    }

}

