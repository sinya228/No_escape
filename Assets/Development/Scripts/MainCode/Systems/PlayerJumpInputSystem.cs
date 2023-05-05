using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed class PlayerJumpInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerComponent, JumpComponent> playerFilter = null;
    public void Run()
    {

        if (!Input.GetKeyDown(KeyCode.Space)) return;

        foreach (var i in playerFilter)
        {

            ref var entity = ref playerFilter.GetEntity(i);
            entity.Get<JumpEvent>();
           

        }

    }

}