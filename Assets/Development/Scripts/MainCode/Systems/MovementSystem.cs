using Leopotam.Ecs;
using UnityEngine;
using System.Collections;


sealed partial class MovementSystem : IEcsRunSystem
{
  

    private readonly EcsFilter<MovableComponent,DirectionComponent> movableFilter = null;
    public void Run()
    {
        foreach (var i in movableFilter)
        {
            ref var movableComponent = ref movableFilter.Get1(i);
            ref var directionComponent = ref movableFilter.Get2(i);

            ref var objectdirection = ref directionComponent.MoveDirection;

            ref var objecttransform = ref movableComponent.ObjectTransform;
            ref var objectcontroller = ref movableComponent.ObjectController;         
            ref var objectspeed = ref movableComponent.ObjectSpeed;

            var rawdirectoin = (objecttransform.forward * objectdirection.z) + (objecttransform.right * objectdirection.x);

            objectcontroller.Move(rawdirectoin * objectspeed * Time.deltaTime);
        }

    }

   
}
          

