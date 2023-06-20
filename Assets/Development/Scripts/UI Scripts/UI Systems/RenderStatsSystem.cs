using Leopotam.Ecs;

sealed class RenderStatsSystem : IEcsRunSystem
{

    private readonly EcsFilter<MessegeBoxFoarmComponent, ButtonComponet, StatsRenderEvent> StatsUIFilter = null;
  
    public void Run()
    {

        foreach (var i in StatsUIFilter)
        {      

            ref var entity = ref StatsUIFilter.GetEntity(i);

            StatsUIFilter.Get1(i).BoxHeader.text = StatsUIFilter.Get2(i).WidgetName.ToString();

            StatsUIFilter.Get1(i).BoxMessege.text = "";

            if (entity.Has<TotalHealthComponent>())
            {
                StatsUIFilter.Get1(i).BoxMessege.text += entity.Get<TotalHealthComponent>().Health.ToString() + " Total Life" + "\n";
            }

            if (entity.Has<TotalMovementSpeedComponent>())
            {
                StatsUIFilter.Get1(i).BoxMessege.text += "\n"+ entity.Get<TotalMovementSpeedComponent>().MovementSpeed.ToString() + " Total Movement Speed\n" + "\n";
            }
           
            if (entity.Has<FlatHealthComponent>()) 
            {
                StatsUIFilter.Get1(i).BoxMessege.text += entity.Get<FlatHealthComponent>().FlatHealth.ToString()+ " To Maximum Life \n Stat Type: FaltHealth, Tier: " + entity.Get<FlatHealthComponent>().FlatHealthTier.ToString() + "\n";
            }

            if (entity.Has<FlatMovementSpeedComponent>())
            {
                StatsUIFilter.Get1(i).BoxMessege.text += "\n" + entity.Get<FlatMovementSpeedComponent>().FlatMovementSpeed.ToString() + " To Maximum Movement Speed \n Stat Type: FlatMovementSpeed, Tier: " + entity.Get<FlatMovementSpeedComponent>().MovementSpeedTier.ToString()+"\n";
            }

            if (entity.Has<IncreasedMovementSpeedComponent>())
            {
                StatsUIFilter.Get1(i).BoxMessege.text += "\n" + entity.Get<IncreasedMovementSpeedComponent>().IncreasedMovementSpeed.ToString() + "% Increased Movement Speed \n Stat Type: IncreasedMovementSpeed, Tier: " + entity.Get<IncreasedMovementSpeedComponent>().MovementSpeedTier.ToString() + "\n";
            }
            
            if (entity.Has<GlobalIncreaseDamageComponent>())
            {
                StatsUIFilter.Get1(i).BoxMessege.text += "\n" + entity.Get<GlobalIncreaseDamageComponent>().IncreaseDamage.ToString() + "% Increased Global Damage \n Stat Type: GlobalIncreaseDamage, Tier: " + entity.Get<GlobalIncreaseDamageComponent>().IncreaseDamageTier.ToString() + "\n";
            }

            if (entity.Has<CritMultiplierComponent>())
            {
                StatsUIFilter.Get1(i).BoxMessege.text += "\n" + entity.Get<CritMultiplierComponent>().CritMultiplier.ToString() + "% Increased Global Critical Multiplier \n Stat Type: CritMultiplier, Tier: " + entity.Get<CritMultiplierComponent>().CritMultiplierTier.ToString() + "\n";
            }
            
           

            StatsUIFilter.GetEntity(i).Del<StatsRenderEvent>();

        }

    }

}