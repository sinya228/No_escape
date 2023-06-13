using Leopotam.Ecs;

sealed partial class InitUIDrawSystem : IEcsInitSystem
{

    private readonly EcsFilter<UIDrawMesegesComponent> DrawFilter = null;


    public void Init()
    {

        foreach (var i in DrawFilter)
        {

            ref var entity = ref DrawFilter.GetEntity(i);
            entity.Get<UIDrawEvent>();

          
        }

    }

}
