using Leopotam.Ecs;
using UnityEngine;



sealed class PlayerMouseInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerComponent, RotationComponent> directionFilter = null;

    private float rotateX = 0;
    private float rotateY = 0;

    public void Run()
    {
       
        SetRotation();

        foreach (var i in directionFilter)
        {
          
            ref var rotationComponent = ref directionFilter.Get2(i);

            ref var rotation = ref rotationComponent.RotateDirection;

            rotation = new Vector3(rotateX, rotateY, 0);


        }

    }

    private void SetRotation()
    {
        rotateY += Input.GetAxis("Mouse X");
        rotateX -= Input.GetAxis("Mouse Y");
    }

}
