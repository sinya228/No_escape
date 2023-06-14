using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;


sealed class FlatHealthMerrigeSystem : IEcsRunSystem
{
    private readonly EcsFilter<FlatHealthComponent,StatGroopIndex>.Exclude<AllStatsComponent> FlatHealthFilter = null;

    private readonly EcsFilter<AllStatsComponent, AddNewStatEvent> AllStatsFilter = null;

    public void Run()
    {

        foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);
        
            foreach (var j in FlatHealthFilter)
            {
            
                if (allstats.Index == FlatHealthFilter.Get2(j).StatsIndex)
                {

                    StatSum += FlatHealthFilter.Get1(j).FlatHealth;
                    AllStatsFilter.GetEntity(i).Get<FlatHealthComponent>().FlatHealth = StatSum;
                }

            }

           

        }

    }

}