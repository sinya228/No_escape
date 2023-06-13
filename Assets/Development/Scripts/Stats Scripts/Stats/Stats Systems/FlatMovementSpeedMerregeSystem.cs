using Leopotam.Ecs;

sealed class FlatMovementSpeedMerregeSystem : IEcsRunSystem
{
    private readonly EcsFilter<FlatMovementSpeedComponent>.Exclude<AllStatsComponent> MovementSpeedFilter = null;

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

                ref var flatmovementspeedstat = ref MovementSpeedFilter.Get1(j);

                if (allstats.Index == flatmovementspeedstat.StatsIndex)
                {
                    StatSum += flatmovementspeedstat.FlatMovementSpeed;
                    entity.Get<FlatMovementSpeedComponent>().FlatMovementSpeed = StatSum;
                }

            }

         

        }

    }

}