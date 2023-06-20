using Leopotam.Ecs;
using UnityEngine;

sealed class MessegeBoxHideSystem : IEcsRunSystem
{

    private readonly EcsFilter<MessegeBoxFoarmComponent>.Exclude<MessegeBoxShowEvent> BoxFoarmHideFilter = null;
       
    public void Run()
    {
        foreach (var i in BoxFoarmHideFilter)
        {

            BoxFoarmHideFilter.Get1(i).BoxObject.position = new Vector2(0,5000);   
            
        }
     
    }

}