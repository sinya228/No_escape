using Leopotam.Ecs;
using System.Collections.Generic;

public class InitItemGenerationSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly AllItemsStatsSO stats = null;

    private readonly EcsFilter<ItemComponent> NewItemFilter = null;

    private readonly Dictionary<ItemBaseEnum, List<StatsSO>> allitems = new Dictionary<ItemBaseEnum, List<StatsSO>>();

    public void Init()
    {
        foreach (var item in stats.ItemsBases)
        {
            if (!allitems.ContainsKey(item.ItemType))
            {
                allitems.Add(item.ItemType, item.AllItemStats);
            }
        }

        foreach (var i in NewItemFilter)
        {
            ref var enity = ref NewItemFilter.GetEntity(i);

            enity.Get<ItemsStatsDictionaryComponent>().AllBaseStats = new Dictionary<StatTypeEnum, List<UnityEngine.Vector2Int>>();

            if (allitems.TryGetValue(NewItemFilter.Get1(i).ItemBase, out List<StatsSO> stat))
            {
                foreach (var s in stat)
                {
                    if (!enity.Get<ItemsStatsDictionaryComponent>().AllBaseStats.ContainsKey(s.StatType))
                    {
                        enity.Get<ItemsStatsDictionaryComponent>().AllBaseStats.Add(s.StatType, s.StatsTierValue);
                    }
                }

            }

        }

    }

    public void Run()
    {
        
    }
}