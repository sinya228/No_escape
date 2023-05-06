using Leopotam.Ecs;
using UnityEngine;

sealed class JumpSystem : IEcsRunSystem
{
    private readonly EcsFilter<JumpEvent,JumpComponent,GravityComponent> jumpFilter = null;
    public void Run()
    {

        foreach (var i in jumpFilter)
        {

            ref var jumpcomponent = ref jumpFilter.Get2(i);
            ref var gravitycomponent = ref jumpFilter.Get3(i);

            gravitycomponent.GravityVelocity = Mathf.Sqrt(-2 * Physics.gravity.y * gravitycomponent.GravityScale * jumpcomponent.JumpHeight);

        }
    }

}