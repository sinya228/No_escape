using Leopotam.Ecs;
using UnityEngine;

sealed class FlatDamageStatsUpdateSystem : IEcsRunSystem
{
    private readonly EcsFilter<FlatDamageStatComponent>.Exclude<AllStatsComponent> FlatDamageFilter = null;

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    public void Run()
    {

        float DamageSum = 0;

        int statsindex;
       

        foreach (var i in AllStatsFilter)
        {

            ref var allstats = ref AllStatsFilter.Get1(i);

            statsindex = allstats.MYIndex;

            foreach (var j in FlatDamageFilter)
            {
                ref var FlatDamageStat = ref FlatDamageFilter.Get1(j);
                if (statsindex == FlatDamageStat.SkillIndex) DamageSum += FlatDamageStat.FlatDamage;
            }

            ref var entity = ref AllStatsFilter.GetEntity(i);
            entity.Get<FlatDamageStatComponent>().FlatDamage = DamageSum;
            
            Debug.Log(allstats.MYName+" " + entity.Get<FlatDamageStatComponent>().FlatDamage);
            
            DamageSum = 0;
        }
        
    }

}

