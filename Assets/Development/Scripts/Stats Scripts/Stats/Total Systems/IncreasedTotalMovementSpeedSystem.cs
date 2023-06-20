using Leopotam.Ecs;
using UnityEngine;

sealed class IncreasedTotalMovementSpeedSystem : IEcsRunSystem
{

    private readonly EcsFilter<TotalMovementSpeedComponent,IncreasedMovementSpeedComponent, AllStatsComponent, StatsUpdateEvent> TotalMSFilter = null;

    public void Run()
    {

        foreach (var i in TotalMSFilter)
        {

            float increasedmovementspeed = TotalMSFilter.Get2(i).IncreasedMovementSpeed;

            TotalMSFilter.Get1(i).MovementSpeed *= (1 + increasedmovementspeed * 0.01f);
      
        }

    }

}
