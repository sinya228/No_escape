using Assets.Development.Entity;
using Leopotam.Ecs;
using UnityEngine;
sealed partial class RaycastSystem : IEcsRunSystem
{
    private readonly EcsFilter<AllStatsComponent, RaycastComponent> RaycastFilter = null;
    private EcsWorld world;
    public void Run()
    {
        foreach (var i in RaycastFilter)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                ref var raycastComponent = ref RaycastFilter.Get2(i);
                if (Physics.Raycast(raycastComponent.startPoint.position, raycastComponent.startPoint.forward, out hit))
                {
                    // ref var e = ref world.NewEntity().Get<HitEvent>();
                    if (hit.collider.TryGetComponent<EntityReference>(out EntityReference n))
                    {
                        var e = hit.collider.GetComponent<EntityReference>()._entity;
                        e.Get<HitEvent>();
                    }
                }
                Debug.DrawRay(raycastComponent.startPoint.position,raycastComponent.startPoint.forward);
                

            }

        }
    }
}
