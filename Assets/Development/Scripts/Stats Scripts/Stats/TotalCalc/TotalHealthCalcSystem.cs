using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;


sealed class TotalHealthCalcSystem: IEcsRunSystem
{

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    private readonly EcsFilter<FlatHealthComponent, AllStatsComponent> FlatHealthFilter = null;

    private readonly EcsFilter<UIDrawMesegesComponent, UIMessegesListComponent> DrawMesegesFilter = null;
    public void Run()
    {

        foreach (var j in AllStatsFilter)
        {

            float totalhealth = 0f;
            string Message = "Defalt Message";

            foreach (var i in FlatHealthFilter)
            {

                if (AllStatsFilter.Get1(j).Index == FlatHealthFilter.Get1(i).StatsIndex)
                {

                    totalhealth +=  FlatHealthFilter.Get1(i).FlatHealth;

                    Message = AllStatsFilter.Get1(j).Name + " have total Flat health = " + FlatHealthFilter.Get1(i).FlatHealth;
                    
                    SendMessege(Message, AllStatsFilter.Get1(j).Index);
                }

            }

       

            ref var entity = ref AllStatsFilter.GetEntity(j);

            entity.Get<TotalHealthComponent>().StatsIndex = AllStatsFilter.Get1(j).Index;
            entity.Get<TotalHealthComponent>().Health = totalhealth;


           

        }

    }
    void SendMessege(string messege, int index)
    {
        foreach (var i in DrawMesegesFilter)
        {
            if (index == DrawMesegesFilter.Get2(i).DrawIndex)
            {
                if (DrawMesegesFilter.Get2(i).MessegeList == null)
                {
                    DrawMesegesFilter.Get2(i).MessegeList = new List<string>();
                }
                DrawMesegesFilter.Get2(i).MessegeList.Add(messege);
            }
        }
    }

}
