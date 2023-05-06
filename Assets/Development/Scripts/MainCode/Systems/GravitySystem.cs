using Leopotam.Ecs;
using UnityEngine;

sealed partial class GravitySystem : IEcsRunSystem
{
    
    private readonly EcsFilter<MovableComponent,GroungCheckComponent,GravityComponent> gravityFilter = null;

    public void Run()
    {

        foreach (var i in gravityFilter)
        {

            ref var movablecomponent = ref gravityFilter.Get1(i);
            ref var grouncheckcomponent = ref gravityFilter.Get2(i);
            ref var gravitycomponent =  ref gravityFilter.Get3(i);

            ref var objectcontroller = ref movablecomponent.ObjectController;

            ref var gravityscale = ref gravitycomponent.GravityScale;



            gravitycomponent.GravityVelocity += Physics.gravity.y* gravityscale * Time.deltaTime;
            gravitycomponent.GravityVelocity = Mathf.Clamp(gravitycomponent.GravityVelocity, gravitycomponent.GravityVelocityLim.x, gravitycomponent.GravityVelocityLim.y);//иначе VelocityY будет постоянно уменьшаться если объект не на земле



            if (gravitycomponent.GravityVelocity >= 0 || !grouncheckcomponent.isGrounded) 
            {
                objectcontroller.Move(Vector3.up * gravitycomponent.GravityVelocity * Time.deltaTime);
            }

        }
      

    }

}
