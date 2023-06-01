using Leopotam.Ecs;
using UnityEngine;

sealed class UnblockDoubleJumpSystem : IEcsRunSystem
{
    private readonly EcsFilter<DoubleJumpBlockEvent> blockFilter = null;

    bool isgrounded;
    public void Run()
    {


        foreach (var i in blockFilter)
        {
            ref var entity = ref blockFilter.GetEntity(i);

            ref var groundcheckcomponent = ref entity.Get<GroungCheckComponent>();

            if (groundcheckcomponent.isGrounded) entity.Del<DoubleJumpBlockEvent>();

        }


    }

}