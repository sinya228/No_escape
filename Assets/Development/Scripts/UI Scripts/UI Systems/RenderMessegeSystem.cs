using Leopotam.Ecs;
using TMPro;
using UnityEngine;

sealed class RenderMessegeSystem : IEcsRunSystem
{

    private readonly EcsFilter<UITextBoxComponent,UITextComponent,UIDrawEvent> RenderMessegeFilter = null;

    public void Run()
    {

        foreach (var i in RenderMessegeFilter)
        {
            RenderMessegeFilter.Get1(i).UITextBox.GetComponentInChildren<TextMeshProUGUI>().text = RenderMessegeFilter.Get2(i).UIText;
            Debug.Log("Updated");
            RenderMessegeFilter.GetEntity(i).Del<UIDrawEvent>();
        }

    }

}