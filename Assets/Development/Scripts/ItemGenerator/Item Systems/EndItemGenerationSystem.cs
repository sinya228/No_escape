using Leopotam.Ecs;


sealed class EndItemGenerationSystem : IEcsRunSystem
{

    private readonly EcsFilter<ItemComponent, UndefinedComponent> ItemFilter = null;
    public void Run()
    {
        foreach (var i in ItemFilter)
        {
            ItemFilter.GetEntity(i).Del<UndefinedComponent>();
        }

    }

}