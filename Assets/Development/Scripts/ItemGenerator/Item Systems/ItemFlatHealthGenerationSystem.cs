using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


sealed class ItemFlatHealthGenerationSystem : IEcsRunSystem
{

    private readonly EcsFilter<ItemComponent, ItemsStatsDictionaryComponent, UndefinedComponent> ItemFilter = null;
    
   
    public void Run()
    {

        int firstrandom = Random.Range(0, 100);

        int stattierindex;

        Vector2Int statminmax;



        foreach (var i in ItemFilter)
        {

            ref var entity = ref ItemFilter.GetEntity(i);

            entity.Del<FlatHealthComponent>();

            if(entity.Get<ItemsStatsDictionaryComponent>().AllBaseStats.TryGetValue(StatTypeEnum.FlatHealth,out List<Vector2Int> stat))
            {

                if (Random.Range(0, 100) < firstrandom)
                {

                    stattierindex = Random.Range(0, stat.Count);

                    statminmax = stat[stattierindex];

                    entity.Get<FlatHealthComponent>().FlatHealth = Random.Range(statminmax.x, statminmax.y);
                    entity.Get<FlatHealthComponent>().FlatHealthTier = stattierindex + 1;
                }

            }
            
        }

    }

}
