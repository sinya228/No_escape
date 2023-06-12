using Leopotam.Ecs;
using UnityEngine;


sealed class SkillDebugSystem : IEcsRunSystem
{
    private readonly EcsFilter<PhysicalTotalDamageComponent,StatsUpdateEvent> TotalDamageFilter = null;



    public void Run()
    {
    
        foreach (var i in TotalDamageFilter)
        {
                     
            //Debug.Log("deal physical =" + TotalDamageFilter.Get1(i).TotalDamage);
        }
       
    }

}

