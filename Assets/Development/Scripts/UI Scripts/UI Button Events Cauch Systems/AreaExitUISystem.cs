using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs;
using System.Collections.Generic;


public class AreaExitUISystem : IEcsRunSystem
{

    private readonly EcsFilter<EcsUiExitEvent> AreaExitFilter = null;

    private readonly EcsFilter<ButtonComponet,MessegeBoxFoarmComponent> BoxFoarmFilter = null;

    private readonly Dictionary<int, int> AreaExitedNameHash = new();

    public void Run()
    {
        //нужно так как все евенты приход€т на еммитор а не на ентити на которой кнопка так что костылим словарь
        foreach (var i in AreaExitFilter)
        {
            if (!AreaExitedNameHash.ContainsKey(AreaExitFilter.Get1(i).WidgetName.GetHashCode()))
            {
                AreaExitedNameHash.Add(AreaExitFilter.Get1(i).WidgetName.GetHashCode(), 0);
            }
        }       

        foreach (var i in BoxFoarmFilter)
        {
            if (AreaExitedNameHash.ContainsKey(BoxFoarmFilter.Get1(i).WidgetName.GetHashCode()))
            {                   
                BoxFoarmFilter.GetEntity(i).Del<MessegeBoxShowEvent>();
            }
        }

        AreaExitedNameHash.Clear();

    }

}
