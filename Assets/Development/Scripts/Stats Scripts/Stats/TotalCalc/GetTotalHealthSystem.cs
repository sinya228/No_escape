using Leopotam.Ecs;
using UnityEngine;

sealed class GetTotalHealthSystem: IEcsRunSystem
{

    private readonly EcsFilter<FlatHealthComponent, AllStatsComponent, StatGroopComponent, StatsUpdateEvent> FlatHealthFilter = null;

    public void Run()
    {
       
        foreach (var i in FlatHealthFilter)
        {

            float totalhealth = FlatHealthFilter.Get1(i).FlatHealth;

            ref var entity = ref FlatHealthFilter.GetEntity(i);

            entity.Get<TotalHealthComponent>().StatsIndex = FlatHealthFilter.Get3(i).StatsIndex;
            entity.Get<TotalHealthComponent>().Health = totalhealth;
          
        }

    }
  
}
