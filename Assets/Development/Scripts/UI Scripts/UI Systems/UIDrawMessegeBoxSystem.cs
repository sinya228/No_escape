using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


sealed class UIDrawMessegeBoxSystem : IEcsRunSystem
{

    private EcsWorld _world;

    private readonly EcsFilter<UIDrawMesegesComponent, UIMessegesListComponent, UIDrawEvent> UIDrawFilter = null;
    
    private readonly EcsFilter<UITextBoxComponent,UIComponent> UIDestroyFilter = null;


   
    public void Run()
    {
      
        foreach (var i in UIDrawFilter)
        {
            
            DestroyMessegeBox(UIDrawFilter.Get2(i).DrawIndex);

            if (UIDrawFilter.Get1(i).MessegeBoxList == null)
            {
                UIDrawFilter.Get1(i).MessegeBoxList = new List<GameObject>();
                
            }
             

            DrawMessegeBox(UIDrawFilter.Get2(i).DrawIndex, UIDrawFilter.Get2(i).MessegeList, UIDrawFilter.Get1(i).MessegeBoxPrefab, UIDrawFilter.Get1(i).MessegeBoxParent);

                             
            UIDrawFilter.GetEntity(i).Del<UIDrawEvent>();
            
        }    

    }

    private void DrawMessegeBox(int index,List<string> MessegeList, GameObject BoxPrefab, Transform BoxParent)
    {
        foreach (var messege in MessegeList)
        {

            var messegebox = _world.NewEntity();
            
            messegebox.Get<UIComponent>().UIIndex = index;

            messegebox.Get<UITextComponent>().UIText = messege;

            messegebox.Get<UITextBoxComponent>().UITextBox = Object.Instantiate(BoxPrefab, BoxParent);
           
        }
       
    }

    private void DestroyMessegeBox(int index)
    {
        foreach (var i in UIDestroyFilter)
        {

            if (index == UIDestroyFilter.Get2(i).UIIndex)
            {
               
                Object.Destroy(UIDestroyFilter.Get1(i).UITextBox);
                UIDestroyFilter.GetEntity(i).Destroy();
            
            }

        }

    }
    
}
