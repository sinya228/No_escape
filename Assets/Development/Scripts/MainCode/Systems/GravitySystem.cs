using Leopotam.Ecs;
using UnityEngine;

sealed partial class GravitySystem : IEcsRunSystem
{
    
    private readonly EcsFilter<MovableComponent> gravityFilter = null;

    Vector3 garvityforce = Vector3.zero;
    public void Run()
    {

        foreach (var i in gravityFilter)
        {
            ref var movableComponent = ref gravityFilter.Get1(i);
        
       
            ref var objectcontroller = ref movableComponent.ObjectController;

            if (garvityforce.y < 0)
            {
                garvityforce = Vector3.zero;
            }


            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                garvityforce.y += Mathf.Sqrt(1000) * Time.deltaTime;

            }



            garvityforce.y += -10* Time.deltaTime;

            objectcontroller.Move(garvityforce);

          
        }

    }

}
