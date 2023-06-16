using Leopotam.Ecs;
using UnityEngine;


sealed class RandomInputSystem : IEcsRunSystem
{


    private readonly EcsFilter<UIDrawMesegesComponent> UIDrawFilter = null;
    private readonly EcsFilter<StatGroopComponent> StatsFrawFilter = null;
    private readonly EcsFilter<ItemComponent> ItemFilter = null;

    public void Run()
    { 

        foreach (var i in UIDrawFilter)
        {

            ref var entity = ref UIDrawFilter.GetEntity(i);

            if (Input.GetKeyDown(KeyCode.Y))
            {

                entity.Get<UIDrawEvent>();

            }

        }

        foreach (var i in StatsFrawFilter)
        {

            ref var entity = ref StatsFrawFilter.GetEntity(i);

            if (Input.GetKeyDown(KeyCode.Y))
            {

                entity.Get<StatsToUIComponent>();
                entity.Get<StatsUpdateEvent>();
                entity.Get<AddNewStatEvent>();
            }

        }

        foreach (var i in ItemFilter)
        {

            ref var entity = ref ItemFilter.GetEntity(i);

            if (Input.GetKeyDown(KeyCode.Y))
            {

                entity.Get<UndefinedComponent>();

            }

        }

    }

}
