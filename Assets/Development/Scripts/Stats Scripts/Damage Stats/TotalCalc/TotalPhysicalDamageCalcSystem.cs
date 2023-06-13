using Leopotam.Ecs;
using UnityEngine;
using System.Collections.Generic;


sealed class TotalPhysicalDamageCalcSystem : IEcsRunSystem
{

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    private readonly EcsFilter<PhysicalFlatDamageComponent, AllStatsComponent> PhysicalFlatFilter = null;

    private readonly EcsFilter<GlobalIncreaseDamageComponent, AllStatsComponent> GlobalIncreaseFilter = null;

    private readonly EcsFilter<FlatCritComponent, AllStatsComponent> FlatCritFilter = null;

    private readonly EcsFilter<CritMultiplierComponent, AllStatsComponent> CritMultiplierFilter = null;

    private readonly EcsFilter<UIDrawMesegesComponent,UIMessegesListComponent> DrawMesegesFilter = null;

    public void Run()
    {

        foreach (var j in AllStatsFilter)
        {
          
            float physicaltotaldamage = 0f;
            float criticalmultiplier = 0f;

            string Message = "Defalt Message";

            foreach (var i in PhysicalFlatFilter)
            {

                if (AllStatsFilter.Get1(j).Index == PhysicalFlatFilter.Get1(i).StatsIndex) 
                {

                    physicaltotaldamage = PhysicalFlatFilter.Get1(i).FlatDamage;

                    Message = AllStatsFilter.Get1(j).Name + " have total Flat damage = " + PhysicalFlatFilter.Get1(i).FlatDamage;

                    SendMessege(Message, AllStatsFilter.Get1(j).Index);
                }
               
            }

            foreach (var i in GlobalIncreaseFilter)
            {

                if (AllStatsFilter.Get1(j).Index == GlobalIncreaseFilter.Get1(i).StatsIndex)
                {

                    physicaltotaldamage *= (1 + GlobalIncreaseFilter.Get1(i).IncreaseDamage*0.01f);

                    Message = AllStatsFilter.Get1(j).Name + " have total Increased damage = " + GlobalIncreaseFilter.Get1(i).IncreaseDamage + "%";
                    SendMessege(Message, AllStatsFilter.Get1(j).Index);
                }

            }

            foreach (var i in CritMultiplierFilter)
            {

                if (AllStatsFilter.Get1(j).Index == CritMultiplierFilter.Get1(i).StatsIndex)
                {

                    criticalmultiplier = CritMultiplierFilter.Get1(i).CritMultiplier * 0.01f;

                    Message = AllStatsFilter.Get1(j).Name + " have total Crit Multiplier = " + CritMultiplierFilter.Get1(i).CritMultiplier + "%";
                    SendMessege(Message, AllStatsFilter.Get1(j).Index);
                }

            }

            
            foreach (var i in FlatCritFilter)
            {

                if (AllStatsFilter.Get1(j).Index == FlatCritFilter.Get1(i).StatsIndex)
                {
                    
                    Message = AllStatsFilter.Get1(j).Name + " have total Crit Chance = " + FlatCritFilter.Get1(i).FlatCrit;
                    SendMessege(Message, AllStatsFilter.Get1(j).Index);
                    
                    int number = Random.Range(1, 100);
                    
                    if (number <= FlatCritFilter.Get1(i).FlatCrit)
                    {
                        physicaltotaldamage *= (1+criticalmultiplier);
                    }

                }

            }

            

            ref var entity = ref AllStatsFilter.GetEntity(j);
            entity.Get<TotalPhysicalDamageComponent>().StatsIndex = AllStatsFilter.Get1(j).Index;
            entity.Get<TotalPhysicalDamageComponent>().PhysicalDamage = physicaltotaldamage;

 
        }

    }
    void SendMessege(string messege, int index) 
    {
        foreach (var i in DrawMesegesFilter)
        {
            if (index == DrawMesegesFilter.Get2(i).DrawIndex)
            {
                if(DrawMesegesFilter.Get2(i).MessegeList== null) 
                {
                    DrawMesegesFilter.Get2(i).MessegeList = new List<string>();
                }
                DrawMesegesFilter.Get2(i).MessegeList.Add(messege);
            }
        }
    }

}

