using Leopotam.Ecs;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

sealed class CursorLockSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<CursorComponent, KeyboardComponent> cursorFilter = null;
    public void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Run()
    {
        ControlCursor();
    }
    public void ControlCursor()
    {
        foreach (var i in cursorFilter)
        {
            ref var curcorComponent = ref cursorFilter.Get1(i);
            ref var keyComponent = ref cursorFilter.Get2(i);

            if (Input.GetKeyDown(keyComponent.keyborDictionary["cursorMod"]))//keyComponent.keyborDictionary["cursorMod"]
            {
                curcorComponent.CursorMode = !curcorComponent.CursorMode;
                Debug.Log("говно");
            }

            if (curcorComponent.CursorMode)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
}
