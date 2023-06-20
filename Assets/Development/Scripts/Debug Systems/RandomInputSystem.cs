using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Actions;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;


sealed class RandomInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<ItemAddEvent> AddFilter = null;

    private readonly EcsFilter<ItemDestroyEvent> DestroyFilter = null;

    private readonly EcsFilter<MessegeBoxFoarmComponent> MessegesListFilter = null;

    private readonly EcsFilter<StatGroopComponent> StatGroopFilter = null;

    private bool updaterequest = false;


    public void Run()
    {

        foreach (var i in AddFilter)
        {
            updaterequest = true;        
        }

        foreach (var i in DestroyFilter)
        {
            updaterequest = true;        
        }

        foreach (var i in MessegesListFilter)
        {

            ref var entity = ref MessegesListFilter.GetEntity(i);
            if (updaterequest)
            {             
                entity.Get<StatsRenderEvent>();             
            }
        }
        
        foreach (var i in StatGroopFilter)
        {

            ref var entity = ref StatGroopFilter.GetEntity(i);
            if (updaterequest)
            {              
                entity.Get<StatsUpdateEvent>();                      
            }
        }

        updaterequest = false;

    }

}
