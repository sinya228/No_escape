using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using System.Collections.Generic;

public class AreaDropUISystem : IEcsRunSystem
{

    private readonly EcsFilter<EcsUiEndDragEvent> DropFilter = null;

    private readonly EcsFilter<ButtonComponet, MessegeBoxFoarmComponent> BoxFoarmFilter = null;

    private readonly Dictionary<int, int> AreaDropNameHash = new();

    public void Run()
    {

        //нужно так как все евенты приход€т на еммитор а не на ентити на которой кнопка так что костылим словарь
        foreach (var i in DropFilter)
        {
            if (!AreaDropNameHash.ContainsKey(DropFilter.Get1(i).WidgetName.GetHashCode()))
            {
                AreaDropNameHash.Add(DropFilter.Get1(i).WidgetName.GetHashCode(), 0);
            }
        }

        foreach (var i in BoxFoarmFilter)
        {
            if (AreaDropNameHash.ContainsKey(BoxFoarmFilter.Get1(i).WidgetName.GetHashCode()))
            {
                BoxFoarmFilter.GetEntity(i).Get<MessegeBoxShowEvent>();          
            }
        }

        AreaDropNameHash.Clear();

    }

}
