using Leopotam.Ecs;
using System.Collections.Generic;

sealed class FlatMovementSpeedMerregeSystem : IEcsRunSystem
{
    private readonly EcsFilter<FlatMovementSpeedComponent,StatGroopComponent>.Exclude<AllStatsComponent> MovementSpeedFilter = null;

    private readonly EcsFilter<AllStatsComponent, StatGroopComponent, AddNewStatEvent> AllStatsFilter = null;
    
    private readonly Dictionary<int, int> movementspeedmodifiers = new Dictionary<int, int>();

    public void Run()
    {

        foreach (var i in MovementSpeedFilter)
        {

            int index = MovementSpeedFilter.Get2(i).StatsIndex;

            if (movementspeedmodifiers.TryGetValue(index, out int currentsum))
            {

                movementspeedmodifiers[index] = currentsum + MovementSpeedFilter.Get1(i).FlatMovementSpeed;

            }
            else
            {

                movementspeedmodifiers.Add(index, MovementSpeedFilter.Get1(i).FlatMovementSpeed);

            }

        }



        foreach (var i in AllStatsFilter)
        {
            AllStatsFilter.GetEntity(i).Del<FlatMovementSpeedComponent>();

            int index = AllStatsFilter.Get2(i).StatsIndex;

            if (movementspeedmodifiers.TryGetValue(index, out int movementspeedsum))
            {

                AllStatsFilter.GetEntity(i).Get<FlatMovementSpeedComponent>().FlatMovementSpeed = movementspeedsum;

            }

        }

        movementspeedmodifiers.Clear();

    }

}