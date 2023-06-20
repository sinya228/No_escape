using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs;
using System.Collections.Generic;

public class AreaEnterUISystem : IEcsRunSystem
{
  
    private readonly EcsFilter<EcsUiEnterEvent> AreaEnterFilter = null;

    private readonly EcsFilter<ButtonComponet,MessegeBoxFoarmComponent> BoxFoarmFilter = null;

    private readonly Dictionary<int,int> AreaEnteredNameHash = new();

 

    public void Run()
    {
        //нужно так как все евенты приход€т на еммитор а не на ентити на которой кнопка так что костылим словарь
        foreach (var i in AreaEnterFilter)
        {
            if (!AreaEnteredNameHash.ContainsKey(AreaEnterFilter.Get1(i).WidgetName.GetHashCode()))
            {              
                AreaEnteredNameHash.Add(AreaEnterFilter.Get1(i).WidgetName.GetHashCode(), 0);              
            }
        }

        foreach (var i in BoxFoarmFilter)
        {
            if (AreaEnteredNameHash.ContainsKey(BoxFoarmFilter.Get1(i).WidgetName.GetHashCode())) 
            {
                BoxFoarmFilter.GetEntity(i).Get<MessegeBoxShowEvent>();                    
            }
        }

        AreaEnteredNameHash.Clear();

    }

}