using Leopotam.Ecs;
using UnityEngine;

sealed class DashSystem : IEcsRunSystem
{
    private readonly EcsFilter<MovableComponent, DirectionComponent, DashEvent> movableFilter = null;

    private float DashTime = 0.1f;

    public void Run()
    {
       
        foreach (var i in movableFilter)
        {
            

            DashTime -= Time.deltaTime;

            ref var entity = ref movableFilter.GetEntity(i);

            if (DashTime <= 0)
            {              
                DashTime = 0.1f;
                entity.Del<DashEvent>();
                Debug.Log("Dashed");
                return;
            }

            ref var movableComponent = ref movableFilter.Get1(i);
            ref var directionComponent = ref movableFilter.Get2(i);
            

            ref var objectdirection = ref directionComponent.MoveDirection;
            ref var objecttransform = ref movableComponent.ObjectTransform;         
  

            var rawdirectoin = (objecttransform.forward * objectdirection.z) + (objecttransform.right * objectdirection.x) + (objecttransform.up * objectdirection.y);
           
            movableComponent.ObjectController.Move(rawdirectoin * 100 * Time.deltaTime);
            


        }


    }

    

}
