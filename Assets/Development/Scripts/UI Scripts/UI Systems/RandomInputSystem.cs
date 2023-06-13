using Leopotam.Ecs;
using UnityEngine;


sealed class RandomInputSystem : IEcsRunSystem
{


    private readonly EcsFilter<UIDrawMesegesComponent> UIDrawFilter = null;


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

    }

}
