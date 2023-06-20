using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

sealed class ItemIncreaseGlobalDamageGenerationSystem : IEcsRunSystem
{ 

    private readonly EcsFilter<ItemComponent, ItemsStatsDictionaryComponent, ItemUndefineEvent> ItemFilter = null;

    public void Run()
    {

        int firstrandom = Random.Range(0, 100);

        int stattierindex;

        Vector2Int statminmax;


        foreach (var i in ItemFilter)
        {
  

            ref var entity = ref ItemFilter.GetEntity(i);

            entity.Del<GlobalIncreaseDamageComponent>();

            if (entity.Get<ItemsStatsDictionaryComponent>().AllBaseStats.TryGetValue(StatTypeEnum.GlobalIncreaseDamage, out List<Vector2Int> stat))
            {

                if (Random.Range(0, 100) < firstrandom)
                {
                    if (ItemFilter.Get1(i).ItemMaxStat > 0)
                    {
                        stattierindex = Random.Range(0, stat.Count);

                        statminmax = stat[stattierindex];

                        entity.Get<GlobalIncreaseDamageComponent>().IncreaseDamage = Random.Range(statminmax.x, statminmax.y);
                        entity.Get<GlobalIncreaseDamageComponent>().IncreaseDamageTier = stattierindex + 1;
                        
                        ItemFilter.Get1(i).ItemMaxStat--;

                    }

                }

            }

        }

    }

}
