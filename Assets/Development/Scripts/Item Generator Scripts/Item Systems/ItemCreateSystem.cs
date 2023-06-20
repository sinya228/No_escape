using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Actions;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
sealed class ItemCreateSystem : IEcsRunSystem
{

    private readonly EcsFilter<ItemSlotComponent,ItemAddEvent> ItemAddFilter = null;

    private readonly EcsWorld world = null;
    private readonly EcsUiEmitter ui = null;

    public void Run()
    {
    
        foreach (var i in ItemAddFilter)
        {
            if(ItemAddFilter.Get1(i).EmptySlot)
            {
                var entity = world.NewEntity();

                //Start Item Generation
                entity.Get<ItemComponent>().ItemBase = ItemAddFilter.Get1(i).ItemSlotType;
                entity.Get<ItemComponent>().ItemMaxStat = 6;
                entity.Get<ItemComponent>().ItemName = "Random " + ItemAddFilter.Get1(i).ItemSlotType.ToString() + " " + Random.Range(0, 9999);

                var Name = entity.Get<ItemComponent>().ItemName;

                ItemAddFilter.Get1(i).HoldedItemName = Name;

                entity.Get<StatGroopComponent>().StatsIndex = 0;
                entity.Get<StatGroopComponent>().Name = Name;



                //Trigger Item Stats Generation
                entity.Get<ItemUndefineEvent>();



                //Start Messege Box Generation System
                var newuiobj = Object.Instantiate(ItemAddFilter.Get1(i).FoarmPrefab, ItemAddFilter.Get1(i).Parent);

                entity.Get<ButtonComponet>().WidgetName = Name;
                entity.Get<ButtonComponet>().ButtonTransform = newuiobj.ButtonTransform;

                entity.Get<MessegeBoxFoarmComponent>().BoxFoarm = newuiobj.BoxFoarmPrefab;
                entity.Get<MessegeBoxFoarmComponent>().BoxObject = newuiobj.BoxTransform;
                entity.Get<MessegeBoxFoarmComponent>().BoxHeader = newuiobj.BoxHeader;
                entity.Get<MessegeBoxFoarmComponent>().BoxMessege = newuiobj.BoxMessege;

                entity.Get<MessegeBoxMovableFoarmComponent>().BoxTransform = newuiobj.BoxTransform;
                entity.Get<MessegeBoxMovableFoarmComponent>().ButtonOffset = newuiobj.BoxOffset;
                entity.Get<MessegeBoxMovableFoarmComponent>().ScreenSize = newuiobj.ScreenSize;

                entity.Get<StatsRenderEvent>();

                EcsUiActionBase.AddAction<EcsUiEnterExitAction>(newuiobj.ButtonTransform.gameObject, Name, ui);
                //End Messege Box Generation System
                //End Item Generation
                ItemAddFilter.Get1(i).EmptySlot = false;
            }
        }

    }

}
