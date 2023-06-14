using Leopotam.Ecs;

sealed class IncreasedMovementSpeedMerregeSystem : IEcsRunSystem
{
    private readonly EcsFilter<IncreasedMovementSpeedComponent,StatGroopIndex>.Exclude<AllStatsComponent> MovementSpeedFilter = null;

    private readonly EcsFilter<AllStatsComponent, AddNewStatEvent> AllStatsFilter = null;

    public void Run()
    {

        foreach (var i in AllStatsFilter)
        {

            int StatSum = 0;

            ref var allstats = ref AllStatsFilter.Get1(i);
         
            foreach (var j in MovementSpeedFilter)
            {

                if (allstats.Index == MovementSpeedFilter.Get2(j).StatsIndex)
                {
                    StatSum += MovementSpeedFilter.Get1(j).IncreasedMovementSpeed;
                    AllStatsFilter.GetEntity(i).Get<IncreasedMovementSpeedComponent>().IncreasedMovementSpeed = StatSum;
                }

            }

           

        }

    }

}
