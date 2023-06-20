using Leopotam.Ecs;

sealed partial class InitStatsSystem : IEcsInitSystem
{
    private readonly EcsFilter<AllStatsComponent> ActiveSkillFilter = null;
    public void Init()
    {
        foreach (var i in ActiveSkillFilter)
        {                        
                ref var entity = ref ActiveSkillFilter.GetEntity(i);          
                entity.Get<StatsUpdateEvent>();
                entity.Get<StatsRenderEvent>();
        }   
    }
}
