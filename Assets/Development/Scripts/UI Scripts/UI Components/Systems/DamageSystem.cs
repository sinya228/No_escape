using Leopotam.Ecs;
using Unity.Burst.CompilerServices;
using UnityEngine;

sealed partial class DamageSystem : IEcsRunSystem
{
    private readonly EcsFilter<HitEvent,HealthComponent> Filter = null;
    public void Run()
    {
        foreach (var i in Filter)
        {
            ref var healthComponent = ref Filter.Get2(i);
            Debug.Log("мне больно");
            healthComponent.health -= 10;
            if(healthComponent.health < 0)
            {

                healthComponent._object.SetActive(false);
            }
        }
    }
}
