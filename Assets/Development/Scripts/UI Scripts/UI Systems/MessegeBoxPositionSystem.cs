using Leopotam.Ecs;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

sealed class MessegeBoxPositionSystem : IEcsRunSystem
{

    private readonly EcsFilter<MessegeBoxMovableFoarmComponent, ButtonComponet, MessegeBoxShowEvent> UIPositionFilter = null;

    public void Run()
    {

        foreach (var i in UIPositionFilter)
        {
            Vector2 boxposition;

            Vector2 screenscale = new(Screen.width / UIPositionFilter.Get1(i).ScreenSize.x, Screen.height / UIPositionFilter.Get1(i).ScreenSize.y);

            Vector2 offset = new(UIPositionFilter.Get1(i).ButtonOffset * screenscale.x, UIPositionFilter.Get1(i).ButtonOffset * screenscale.y);

            Vector2 buttonposition =  UIPositionFilter.Get2(i).ButtonTransform.transform.position;
            
            Vector2 rectwithheight = new (UIPositionFilter.Get1(i).BoxTransform.sizeDelta.x * screenscale.x, UIPositionFilter.Get1(i).BoxTransform.sizeDelta.y * screenscale.y);

     
            //render up , center
            boxposition = new Vector2(buttonposition.x, buttonposition.y+ (rectwithheight.y/2+ offset.y));


            //render left , right boarder
            if (buttonposition.x > Screen.width - (rectwithheight.x / 2 + offset.x))
            {
                boxposition = new Vector2(buttonposition.x - (rectwithheight.x / 2 + offset.x), buttonposition.y);
            }

            //render left , up boarder , right up corner
            if (buttonposition.y > Screen.height - (rectwithheight.y + offset.y))
            {
                boxposition = new Vector2(buttonposition.x - (rectwithheight.x / 2 + offset.x), Screen.height - rectwithheight.y / 2);
            }
            
            //render right , left boarder
            if (buttonposition.x < 0 + (rectwithheight.x / 2 + offset.x)) 
            {
                boxposition = new Vector2(buttonposition.x + ((rectwithheight.x/2)+ offset.x), buttonposition.y);
            }

            //render right ,left down corner
            if (buttonposition.x < 0 + (rectwithheight.x / 2 + offset.x) && buttonposition.y < 0 + rectwithheight.y/2)
            {
                boxposition = new Vector2(buttonposition.x + (rectwithheight.x / 2+ offset.x), 0 + rectwithheight.y / 2);
            }

            //render right ,left up corner
            if (buttonposition.x < 0 + (rectwithheight.x / 2 + offset.x) && buttonposition.y > Screen.height - rectwithheight.y/2)
            {
                boxposition = new Vector2(buttonposition.x + (rectwithheight.x / 2 + offset.x), Screen.height - rectwithheight.y / 2);
            }
            
            //render left ,right down corner
            if (buttonposition.x > Screen.width - (rectwithheight.x / 2 + offset.x) && buttonposition.y < 0 + rectwithheight.y / 2)
            {
                boxposition = new Vector2(buttonposition.x - (rectwithheight.x / 2 + offset.x), 0 + rectwithheight.y / 2);
            }

            UIPositionFilter.Get1(i).BoxTransform.transform.position = boxposition;
      
        }

    }

}
