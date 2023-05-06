using Leopotam.Ecs;
using UnityEngine;

sealed partial class WallCheckSystem : IEcsRunSystem
{

    private readonly EcsFilter<GroungCheckComponent> groundcheckFilter = null;


    public void Run()
    {

        foreach (var i in groundcheckFilter)
        {

            ref var groundcheckcomponent = ref groundcheckFilter.Get1(i);


            ref var objecttransform = ref groundcheckcomponent.GrounCheckTransform;
            ref var grounchecksphereradius = ref groundcheckcomponent.GrounCheckTransRadius;
            ref var layermask = ref groundcheckcomponent.WallMask;


            if (Physics.CheckSphere(objecttransform.position, grounchecksphereradius, layermask))
            {
                groundcheckcomponent.isGrounded = true;
                Debug.Log("WALL");

            }
            else
            {
                groundcheckcomponent.isGrounded = false;
            }

        }

    }

}

