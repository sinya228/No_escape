using Leopotam.Ecs;

sealed class PhysicalFlatDamageMerregeSystem : IEcsRunSystem
{
   

    public void Run()
    {
    
        /*foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;
          
            ref var allstats = ref AllStatsFilter.Get1(i);
            
            foreach (var j in FlatDamageFilter)
            {

                ref var flatdamagestat = ref FlatDamageFilter.Get1(j);

                if (allstats.Index == flatdamagestat.StatsIndex) 
                {
                    StatSum += flatdamagestat.FlatDamage;                
                }

            }

            AllStatsFilter.GetEntity(i).Get<PhysicalFlatDamageComponent>().FlatDamage = StatSum;

        }*/
        
    }

}

