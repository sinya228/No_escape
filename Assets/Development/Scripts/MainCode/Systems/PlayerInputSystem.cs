using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerComponent, DirectionComponent> directionFilter = null;

    private float moveX;
    private float moveZ;

    public void Run()
    {
        SetDirection();

        foreach (var i in directionFilter)
        {

            ref var directionComponent = ref directionFilter.Get2(i);
            
            ref var direction = ref directionComponent.MoveDirection;

            direction = new Vector3(moveX,0,moveZ);

        }

    }

    private void SetDirection()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }
}


