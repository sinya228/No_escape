using Leopotam.Ecs;
using System.Collections.Generic;

sealed class IncreasedMovementSpeedMerregeSystem : IEcsRunSystem
{
    private readonly EcsFilter<IncreasedMovementSpeedComponent,StatGroopComponent>.Exclude<AllStatsComponent> MovementSpeedFilter = null;

    private readonly EcsFilter<StatGroopComponent, AllStatsComponent,StatsUpdateEvent> AllStatsFilter = null;

    private readonly Dictionary<int, int> movementspeedmodifiers = new Dictionary<int, int>();

    public void Run()
    {

        foreach (var i in MovementSpeedFilter)
        {

            int index = MovementSpeedFilter.Get2(i).StatsIndex;

            if (movementspeedmodifiers.TryGetValue(index, out int currentsum))
            {
                movementspeedmodifiers[index] = currentsum + MovementSpeedFilter.Get1(i).IncreasedMovementSpeed;
            }
            else
            {
                movementspeedmodifiers.Add(index, MovementSpeedFilter.Get1(i).IncreasedMovementSpeed);
            }

        }



        foreach (var i in AllStatsFilter)
        {

            AllStatsFilter.GetEntity(i).Del<IncreasedMovementSpeedComponent>();

            int index = AllStatsFilter.Get1(i).StatsIndex;

            if (movementspeedmodifiers.TryGetValue(index, out int movementspeedsum))
            {
                AllStatsFilter.GetEntity(i).Get<IncreasedMovementSpeedComponent>().IncreasedMovementSpeed= movementspeedsum;
            }

        }

        movementspeedmodifiers.Clear();

    }

}
