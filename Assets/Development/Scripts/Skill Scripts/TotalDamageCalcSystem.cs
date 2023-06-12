using Leopotam.Ecs;
using UnityEngine;


sealed class TotalDamageCalcSystem : IEcsRunSystem
{

    private readonly EcsFilter<PhysicalTotalDamageComponent, AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    private readonly EcsFilter<PhysicalFlatDamageComponent, AllStatsComponent> PhysicalFlatFilter = null;

    private readonly EcsFilter<GlobalIncreaseDamageComponent, AllStatsComponent> GlobalIncreaseFilter = null;

    private readonly EcsFilter<FlatCritComponent, AllStatsComponent> FlatCritFilter = null;

    private readonly EcsFilter<CritMultiplierComponent, AllStatsComponent> CritMultiplierFilter = null;

    public void Run()
    {

        foreach (var j in AllStatsFilter)
        {
          
            float physicaltotaldamage = 0f;
            float criticalmultiplier = 0f;

            foreach (var i in PhysicalFlatFilter)
            {

                if (AllStatsFilter.Get2(j).Index == PhysicalFlatFilter.Get1(i).StatsIndex) 
                {

                    physicaltotaldamage = PhysicalFlatFilter.Get1(i).FlatDamage;

                    Debug.Log(AllStatsFilter.Get2(j).Name + " have total Flat damage =" + PhysicalFlatFilter.Get1(i).FlatDamage);

                }
               
            }

            foreach (var i in GlobalIncreaseFilter)
            {

                if (AllStatsFilter.Get2(j).Index == GlobalIncreaseFilter.Get1(i).StatsIndex)
                {

                    physicaltotaldamage *= (1 + GlobalIncreaseFilter.Get1(i).IncreaseDamage*0.01f);

                    Debug.Log(AllStatsFilter.Get2(j).Name + " have total Increased damage =" + GlobalIncreaseFilter.Get1(i).IncreaseDamage);

                }

            }

            foreach (var i in CritMultiplierFilter)
            {

                if (AllStatsFilter.Get2(j).Index == CritMultiplierFilter.Get1(i).StatsIndex)
                {

                    criticalmultiplier = CritMultiplierFilter.Get1(i).CritMultiplier * 0.01f;

                    Debug.Log(AllStatsFilter.Get2(j).Name + " have total Crit Multiplier damage =" + CritMultiplierFilter.Get1(i).CritMultiplier);
                                     
                }

            }

            
            foreach (var i in FlatCritFilter)
            {

                if (AllStatsFilter.Get2(j).Index == FlatCritFilter.Get1(i).StatsIndex)
                {
                    Debug.Log(AllStatsFilter.Get2(j).Name + " have total Crit Chance damage =" + FlatCritFilter.Get1(i).FlatCrit);
                    
                    int number = Random.Range(1, 100);
                    
                    if (number <= FlatCritFilter.Get1(i).FlatCrit)
                    {
                        physicaltotaldamage *= (1+criticalmultiplier);
                    }

                }

            }
           
            AllStatsFilter.Get1(j).TotalDamage = physicaltotaldamage;

            Debug.Log(AllStatsFilter.Get2(j).Name + " Deal Total Physical Damage =" + physicaltotaldamage);

        }

    }

}

