using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
sealed class ItemDestroySystem : IEcsRunSystem
{


    private readonly EcsFilter<ItemComponent> ItemFilter = null;
    
    private readonly EcsFilter<ItemSlotComponent, ItemDestroyEvent> ItemDestroyFilter = null;

    private readonly Dictionary<int,int> ItemsSlot = new();

    public void Run()
    {
        foreach (var i in ItemDestroyFilter)
        {
            if(!ItemsSlot.ContainsKey(ItemDestroyFilter.Get1(i).HoldedItemName.GetHashCode()))
            {
                ItemsSlot.Add(ItemDestroyFilter.Get1(i).HoldedItemName.GetHashCode(), 0);
            }
        }


        foreach (var i in ItemFilter)
        {
            if (ItemsSlot.ContainsKey(ItemFilter.Get1(i).ItemName.GetHashCode()))
            {
                Object.Destroy(ItemFilter.GetEntity(i).Get<MessegeBoxFoarmComponent>().BoxFoarm);
                ItemFilter.GetEntity(i).Destroy();
            }
        }

    }

}

