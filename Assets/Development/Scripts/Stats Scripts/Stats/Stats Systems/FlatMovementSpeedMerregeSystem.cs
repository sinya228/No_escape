using Leopotam.Ecs;

sealed class FlatMovementSpeedMerregeSystem : IEcsRunSystem
{
    private readonly EcsFilter<FlatMovementSpeedComponent,StatGroopIndex>.Exclude<AllStatsComponent> MovementSpeedFilter = null;

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
                    StatSum += MovementSpeedFilter.Get1(j).FlatMovementSpeed;
                    AllStatsFilter.GetEntity(i).Get<FlatMovementSpeedComponent>().FlatMovementSpeed = StatSum;
                }

            }

           

        }

    }

}