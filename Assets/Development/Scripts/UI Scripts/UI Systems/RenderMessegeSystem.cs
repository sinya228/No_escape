using Leopotam.Ecs;
using TMPro;



sealed class RenderMessegeSystem : IEcsRunSystem
{



    private readonly EcsFilter<UITextBoxComponent,UIComponent,UITextComponent> RenderMessegeFilter = null;

  

    public void Run()
    {

        foreach (var i in RenderMessegeFilter)
        {

            RenderMessegeFilter.Get1(i).UITextBox.GetComponentInChildren<TextMeshProUGUI>().text = RenderMessegeFilter.Get3(i).UIText;

        }

    }

}