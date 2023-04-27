using Leopotam.Ecs;
public partial class EcsGameStartup
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<playerTag, DirectionComponent> directionComponent = null;

        public void Run()
        {
            foreach (var i in directionFilter)
            {
                ref var directionComponent = ref directionComponentFilter.Get2(i);
            }
        }
    }
}
