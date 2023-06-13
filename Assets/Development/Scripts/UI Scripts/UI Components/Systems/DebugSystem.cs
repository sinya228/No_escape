using Leopotam.Ecs;
using UnityEngine;

sealed partial class DebugSystem : IEcsRunSystem
{
    private readonly EcsFilter<HitEvent> Filter = null;
    public void Run()
    {
        foreach (var i in Filter)
        {
            Debug.Log("ща поиграем");
        }
    }
}