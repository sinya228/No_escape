using Leopotam.Ecs;
public partial class EcsGameStartup
{
    sealed partial class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<MovableComponent> MovableFilter = null;
        public void Run()
        {

        }
    }
}
