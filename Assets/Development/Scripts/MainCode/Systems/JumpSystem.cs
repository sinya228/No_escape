using Leopotam.Ecs;
using UnityEngine;

sealed class JumpSystem : IEcsRunSystem
{
    private readonly EcsFilter<JumpEvent,GroungCheckComponent,JumpComponent, MovableComponent> jumpFilter = null;
    public void Run()
    {

        foreach (var i in jumpFilter)
        {

            ref var entity = ref jumpFilter.GetEntity(i);
            
            ref var groundcheck = ref jumpFilter.Get2(i);
            
            ref var jumpcomponent = ref jumpFilter.Get3(i);
            
            ref var movablecomponent = ref jumpFilter.Get4(i);

            ref var objectcontroller = ref movablecomponent.ObjectController;

            //if (!jumpcomponent.a) continue;

            objectcontroller.Move(movablecomponent.ObjectTransform.up *jumpcomponent.JumpForce*Time.deltaTime);


        }
    }

}