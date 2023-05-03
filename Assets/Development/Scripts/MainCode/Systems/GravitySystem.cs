using Leopotam.Ecs;
using UnityEngine;

sealed partial class GravitySystem : IEcsRunSystem
{
    
    private readonly EcsFilter<MovableComponent> gravityFilter = null;

    public void Run()
    {

        foreach (var i in gravityFilter)
        {
            ref var movableComponent = ref gravityFilter.Get1(i);
        
       
            ref var objectcontroller = ref movableComponent.ObjectController;
            ref var garvityforce = ref movableComponent.GravityForce;

            Vector3 gravitydirectoin = new Vector3(0, -garvityforce, 0);

            objectcontroller.Move(gravitydirectoin*Time.deltaTime);
        }

    }

}
