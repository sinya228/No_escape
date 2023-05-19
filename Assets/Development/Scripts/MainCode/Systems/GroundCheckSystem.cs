using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

sealed partial class GroundCheckSystem : IEcsRunSystem
{

    private readonly EcsFilter<GroungCheckComponent> groundcheckFilter = null;


    public void Run()
    {

        foreach (var i in groundcheckFilter)
        {
                      
            ref var groundcheckcomponent = ref groundcheckFilter.Get1(i);


            ref var objecttransform = ref groundcheckcomponent.GrounCheckTransform;
            ref var grounchecksphereradius = ref groundcheckcomponent.GrounCheckTransRadius;
            ref var layermask = ref groundcheckcomponent.GroundMask;

          
            if (Physics.CheckSphere(objecttransform.position, grounchecksphereradius, layermask))
            {
                groundcheckcomponent.isGrounded = true;
               // Debug.Log("Ground");

            }
            else 
            {
                groundcheckcomponent.isGrounded = false;
             
            }

        }

    }

}
