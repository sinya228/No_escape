using Leopotam.Ecs;
using UnityEngine;


sealed class GetTotalMovementSpeedSystem : IEcsRunSystem
{
   
    private readonly EcsFilter<FlatMovementSpeedComponent, AllStatsComponent, StatGroopComponent, StatsUpdateEvent> FlatMSFilter = null;

    public void Run()
    {

        foreach (var i in FlatMSFilter)
        {

            float totalmovementspeed = FlatMSFilter.Get1(i).FlatMovementSpeed;

            ref var entity = ref FlatMSFilter.GetEntity(i);

            entity.Get<TotalMovementSpeedComponent>().StatsIndex = FlatMSFilter.Get3(i).StatsIndex;
            entity.Get<TotalMovementSpeedComponent>().MovementSpeed = totalmovementspeed;

  

        }

    }

}


