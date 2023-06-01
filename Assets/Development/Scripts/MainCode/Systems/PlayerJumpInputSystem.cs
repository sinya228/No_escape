using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerJumpInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerComponent, JumpComponent> playerFilter = null;

 
    public void Run()
    {


        foreach (var i in playerFilter)
        {
                     
            if (!Input.GetKeyDown(KeyCode.Space)) return;


            ref var entity = ref playerFilter.GetEntity(i);
            entity.Get<JumpEvent>();

        }


    }

}