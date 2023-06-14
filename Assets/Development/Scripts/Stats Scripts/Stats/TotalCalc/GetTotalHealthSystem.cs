using Leopotam.Ecs;
using UnityEngine;

sealed class GetTotalHealthSystem: IEcsRunSystem
{

    private readonly EcsFilter<FlatHealthComponent, AllStatsComponent, StatsUpdateEvent> FlatHealthFilter = null;

    public void Run()
    {
       
        foreach (var i in FlatHealthFilter)
        {

            float totalhealth = FlatHealthFilter.Get1(i).FlatHealth;

            ref var entity = ref FlatHealthFilter.GetEntity(i);

            entity.Get<TotalHealthComponent>().StatsIndex = FlatHealthFilter.Get2(i).Index;
            entity.Get<TotalHealthComponent>().Health = totalhealth;
          
        }

    }
  
}
