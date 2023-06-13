using Leopotam.Ecs;

sealed class IncreasedMovementSpeedMerregeSystem : IEcsRunSystem
{
    private readonly EcsFilter<IncreasedMovementSpeedComponent>.Exclude<AllStatsComponent> MovementSpeedFilter = null;

    private readonly EcsFilter<AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    public void Run()
    {

        foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);

            ref var entity = ref AllStatsFilter.GetEntity(i);



            foreach (var j in MovementSpeedFilter)
            {

                ref var increasedmovementspeedstat = ref MovementSpeedFilter.Get1(j);

                if (allstats.Index == increasedmovementspeedstat.StatsIndex)
                {
                    StatSum += increasedmovementspeedstat.IncreasedMovementSpeed;
                    entity.Get<IncreasedMovementSpeedComponent>().IncreasedMovementSpeed = StatSum;
                }

            }

        
        }

    }

}
