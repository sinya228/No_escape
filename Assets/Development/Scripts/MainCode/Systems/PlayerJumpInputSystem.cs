using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed class PlayerJumpInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerComponent, JumpComponent,GroungCheckComponent> playerFilter = null;

    bool isgrounded;
    public void Run()
    {


        foreach (var i in playerFilter)
        {
            ref var groungcheckcomponent = ref playerFilter.Get3(i);
            
            if (!Input.GetKeyDown(KeyCode.Space) || !groungcheckcomponent.isGrounded)
            {
                return;
            }

        }


        foreach (var i in playerFilter)
        {

            ref var entity = ref playerFilter.GetEntity(i);
            entity.Get<JumpEvent>();
           

        }

    }

}