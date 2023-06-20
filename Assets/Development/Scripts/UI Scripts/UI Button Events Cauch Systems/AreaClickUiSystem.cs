using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs;
using System.Collections.Generic;

public class AreaClickUiSystem : IEcsRunSystem
{

    private readonly EcsFilter<EcsUiClickEvent> ClickFilter = null;

    private readonly EcsFilter<ButtonComponet, MessegeBoxFoarmComponent> BoxFoarmFilter = null;

    private readonly EcsFilter<ButtonComponet,ItemSlotComponent>.Exclude<ItemAddEvent> AdditemFilter = null;

    private readonly Dictionary<int, bool> AreaClickNameHash = new();

    public void Run()
    {
       
        //нужно так как все евенты приход€т на еммитор а не на ентити на которой кнопка так что костылим словарь
        foreach (var i in ClickFilter)
        {
            if (!AreaClickNameHash.ContainsKey(ClickFilter.Get1(i).WidgetName.GetHashCode()))
            {
                AreaClickNameHash.Add(ClickFilter.Get1(i).WidgetName.GetHashCode(), false);
            }
            else 
            {
                AreaClickNameHash[ClickFilter.Get1(i).WidgetName.GetHashCode()] = !AreaClickNameHash[ClickFilter.Get1(i).WidgetName.GetHashCode()];
            }
        }

        foreach (var i in BoxFoarmFilter)
        {
            if (AreaClickNameHash.TryGetValue(BoxFoarmFilter.Get1(i).WidgetName.GetHashCode(), out bool toggeled))
            {
                if (!toggeled)
                {
                    BoxFoarmFilter.GetEntity(i).Get<MessegeBoxShowEvent>();                   
                }
                else 
                {
                    BoxFoarmFilter.GetEntity(i).Del<MessegeBoxShowEvent>();
                    AreaClickNameHash.Remove(BoxFoarmFilter.Get1(i).WidgetName.GetHashCode());
                }
                
            }

        }

        foreach (var i in AdditemFilter)
        {
            if (AreaClickNameHash.TryGetValue(AdditemFilter.Get1(i).WidgetName.GetHashCode(), out bool toggeled))
            {
                if (!toggeled)
                {
                    if (AdditemFilter.Get2(i).EmptySlot)
                    {                
                        AdditemFilter.GetEntity(i).Get<ItemAddEvent>();
                    }
                }
                else
                {
                    if (!AdditemFilter.Get2(i).EmptySlot)
                    {                     
                        AdditemFilter.GetEntity(i).Get<ItemDestroyEvent>();
                        AdditemFilter.Get2(i).EmptySlot = !AdditemFilter.Get2(i).EmptySlot;
                        AreaClickNameHash.Remove(AdditemFilter.Get1(i).WidgetName.GetHashCode());
                    }

                }

            }

        }
    
    }

}
