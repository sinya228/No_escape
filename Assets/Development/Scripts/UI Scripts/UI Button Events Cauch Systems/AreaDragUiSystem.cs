using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using System.Collections.Generic;
using UnityEngine;

public class AreaDragUiSystem : IEcsRunSystem
{

    private readonly EcsFilter<EcsUiDragEvent> DragFilter = null;

    private readonly EcsFilter<ButtonComponet,MessegeBoxFoarmComponent> BoxFoarmFilter = null;

    private readonly Dictionary<int, Vector2> AreaStartDraggNameHash = new();

    public void Run()
    {
  
        //����� ��� ��� ��� ������ �������� �� ������� � �� �� ������ �� ������� ������ ��� ��� �������� �������
        foreach (var i in DragFilter)
        {
            if (!AreaStartDraggNameHash.ContainsKey(DragFilter.Get1(i).WidgetName.GetHashCode()))
            {
                AreaStartDraggNameHash.Add(DragFilter.Get1(i).WidgetName.GetHashCode(), DragFilter.Get1(i).Position);
            }
        }

        foreach (var i in BoxFoarmFilter)
        {      
            if (AreaStartDraggNameHash.TryGetValue(BoxFoarmFilter.Get1(i).WidgetName.GetHashCode(), out Vector2 position))
            {
                BoxFoarmFilter.GetEntity(i).Del<MessegeBoxShowEvent>();
                
                BoxFoarmFilter.Get1(i).ButtonTransform.position = position;
            }
        }

        AreaStartDraggNameHash.Clear();

    }

}