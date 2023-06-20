using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

sealed class StatBasetSpeedSystem : IEcsRunSystem
{

    private readonly EcsFilter<StatGroopComponent,TotalMovementSpeedComponent,AllStatsComponent> StatFilter = null;

    private readonly EcsFilter<MovableComponent,StatsBasedMovableComponent> MovableFilter = null;

    private Dictionary<int, float> statindexes = new();

    public void Run()
    {

        foreach (var i in StatFilter)
        {
            if(!statindexes.ContainsKey(StatFilter.Get1(i).StatsIndex))
            {
                statindexes.Add(StatFilter.Get1(i).StatsIndex, StatFilter.Get2(i).MovementSpeed);
            }

        }

        foreach (var i in MovableFilter)
        {
            if (statindexes.ContainsKey(MovableFilter.Get2(i).StatsIndex)) 
            {
                MovableFilter.Get1(i).ObjectSpeed = statindexes[MovableFilter.Get2(i).StatsIndex];
            }
         
        }
        statindexes.Clear();
    }

}

