using Leopotam.Ecs;
using UnityEngine;

sealed class RenderStatsUISystem : IEcsRunSystem
{

    private readonly EcsFilter<FlatHealthComponent,AllStatsComponent, ToUIComponent> HealthDrawUIFilter = null;

    
    private readonly EcsFilter<UIMessegesListComponent,UIComponent> MessegeListFilter = null;

    public void Run()
    {
        foreach (var i in HealthDrawUIFilter)
        {
   
            foreach (var j in MessegeListFilter)
            {
                if (HealthDrawUIFilter.Get2(i).Index == MessegeListFilter.Get2(j).UIIndex) 
                {
                     
                    MessegeListFilter.Get1(j).MessegeList.Add(HealthDrawUIFilter.Get2(i).Name.ToString() + " Have Total Flat Health = " + HealthDrawUIFilter.Get1(i).FlatHealth.ToString());
                  
                }

            }

            HealthDrawUIFilter.GetEntity(i).Del<ToUIComponent>();

        }

        
    }

}