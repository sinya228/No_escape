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
        //����� ��� ��� ��� ������ �������� �� ������� � �� �� ������ �� ������� ������ ��� ��� �������� �������
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
