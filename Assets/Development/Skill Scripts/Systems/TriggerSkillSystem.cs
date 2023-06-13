using Leopotam.Ecs;
using UnityEngine;

sealed partial class TriggerSkillSystem : IEcsRunSystem
{

    private readonly EcsFilter<AllStatsComponent> ActiveSkillFilter = null;


    public void Run()
    {

        foreach (var i in ActiveSkillFilter)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                
                ref var entity = ref ActiveSkillFilter.GetEntity(i);
                entity.Get<StatsUpdateEvent>();

            }
           
        }

    }

}

