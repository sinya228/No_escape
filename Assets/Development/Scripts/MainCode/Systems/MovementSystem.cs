using Leopotam.Ecs;
using UnityEngine;

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

            Vector3 rawdirectoin = (objecttransform.forward * objectdirection.z) + (objecttransform.right * objectdirection.x)+ (objecttransform.up * objectdirection.y);

            objectcontroller.Move(rawdirectoin * objectspeed * Time.deltaTime);
        }

    }

   
}
          

