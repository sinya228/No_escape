using Leopotam.Ecs;
using UnityEngine;


sealed class GetTotalMovementSpeedSystem : IEcsRunSystem
{
   
    private readonly EcsFilter<FlatMovementSpeedComponent, AllStatsComponent, StatsUpdateEvent> FlatMSFilter = null;

    public void Run()
    {

        foreach (var i in FlatMSFilter)
        {

            float totalmovementspeed = FlatMSFilter.Get1(i).FlatMovementSpeed;

            ref var entity = ref FlatMSFilter.GetEntity(i);

            entity.Get<TotalMovementSpeedComponent>().StatsIndex = FlatMSFilter.Get2(i).Index;
            entity.Get<TotalMovementSpeedComponent>().MovementSpeed = totalmovementspeed;

            Debug.Log(entity.Get<TotalMovementSpeedComponent>().MovementSpeed);
           
        }

    }

}


