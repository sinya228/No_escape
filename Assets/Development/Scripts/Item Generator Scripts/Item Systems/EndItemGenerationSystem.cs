using Leopotam.Ecs;
using UnityEngine;

sealed class EndItemGenerationSystem : IEcsRunSystem
{

    private readonly EcsFilter<ItemComponent, ItemUndefineEvent> ItemFilter = null;
    public void Run()
    {
        foreach (var i in ItemFilter)
        {
            ItemFilter.GetEntity(i).Del<UndefinedComponent>();
            ItemFilter.GetEntity(i).Del<ItemUndefineEvent>();
  
        }

    }

}