using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;


sealed class MessegeBoxShowSystem : IEcsRunSystem
{
 
    private readonly EcsFilter<MessegeBoxFoarmComponent, MessegeBoxShowEvent> EnterShowFilter = null;


    public void Run()
    {
      
        foreach (var i in EnterShowFilter)
        {
            //EnterShowFilter.Get1(i).BoxObject.gameObject.SetActive(true);          
        }
      
    }

}
