using Leopotam.Ecs;
using UnityEngine;



sealed class RotationSystem : IEcsRunSystem,IEcsInitSystem
{   
    private readonly EcsFilter<RotationComponent> rotationFilter = null;


    private Quaternion ObjectStartRotation;

    public void Init() 
    {
        foreach (var i in rotationFilter)
        {

            ref var rotationComponent = ref rotationFilter.Get1(i);

            ref var objecttransform = ref rotationComponent.ObjectTransform;

            ObjectStartRotation = objecttransform.rotation;

        }
    }


    public void Run()
    {
       
        foreach (var i in rotationFilter)
        {
          
            ref var rotationComponent = ref rotationFilter.Get1(i);

            ref var objecttransform = ref rotationComponent.ObjectTransform;           
            ref var rotationspeed = ref rotationComponent.ObjectRotationSpeed;          
            ref var rotateangle = ref rotationComponent.RotateDirection;


          

            if (rotationComponent.ConstrainX)
            {
                rotateangle.x = 0;
            }

            if (rotationComponent.ConstrainY)
            {
                rotateangle.y = 0;
            }

            if (rotationComponent.ConstrainZ)
            {
                rotateangle.z = 0;
            }


            objecttransform.localRotation = ObjectStartRotation * Quaternion.Euler(rotateangle);
        }    

    }

}
