using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;


sealed class TotalMovementSpeedCalcSystem : IEcsRunSystem
{

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    private readonly EcsFilter<IncreasedMovementSpeedComponent, AllStatsComponent> IncreaseMovementSpeedFilter = null;

    private readonly EcsFilter<FlatMovementSpeedComponent, AllStatsComponent> FlatMovementSpeedFilter = null;
   
    private readonly EcsFilter<StatsBasedMovableComponent, MovableComponent> MovableFilter = null;

    private readonly EcsFilter<UIDrawMesegesComponent, UIMessegesListComponent> DrawMesegesFilter = null;

    public void Run()
    {

        foreach (var j in AllStatsFilter)
        {

            float totalmovementspeed = 0f;
            string Message = "Defalt Message";

            foreach (var i in FlatMovementSpeedFilter)
            {

                if (AllStatsFilter.Get1(j).Index == FlatMovementSpeedFilter.Get1(i).StatsIndex)
                {

                    totalmovementspeed += FlatMovementSpeedFilter.Get1(i).FlatMovementSpeed;

                    Message = AllStatsFilter.Get1(j).Name + " have total Flat MS = " + FlatMovementSpeedFilter.Get1(i).FlatMovementSpeed;
                    SendMessege(Message, AllStatsFilter.Get1(j).Index);
                }

            }


            foreach (var i in IncreaseMovementSpeedFilter)
            {

                if (AllStatsFilter.Get1(j).Index == IncreaseMovementSpeedFilter.Get1(i).StatsIndex)
                {

                    totalmovementspeed *= (1 + IncreaseMovementSpeedFilter.Get1(i).IncreasedMovementSpeed * 0.01f);

                    Message = AllStatsFilter.Get1(j).Name + " have total Increased MS = " + IncreaseMovementSpeedFilter.Get1(i).IncreasedMovementSpeed + "%";

                    SendMessege(Message, AllStatsFilter.Get1(j).Index);
                }

            }

         
            
            ref var entity = ref AllStatsFilter.GetEntity(j);

            entity.Get<TotalMovementSpeedComponent>().StatsIndex = AllStatsFilter.Get1(j).Index;
            entity.Get<TotalMovementSpeedComponent>().MovementSpeed = totalmovementspeed;

            foreach (var i in MovableFilter)
            {

                if (AllStatsFilter.Get1(j).Index == MovableFilter.Get1(i).StatsIndex)
                {

                    MovableFilter.Get2(i).ObjectSpeed = entity.Get<TotalMovementSpeedComponent>().MovementSpeed;

                }

            }

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

