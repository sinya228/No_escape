using Leopotam.Ecs;
using System.Collections.Generic;

sealed class FlatCritMerregeSystem : IEcsRunSystem
{
       
    private readonly EcsFilter<FlatCritComponent, StatGroopComponent>.Exclude<AllStatsComponent> FlatMultiplierFilter = null;

    private readonly EcsFilter<AllStatsComponent, StatGroopComponent, AddNewStatEvent> AllStatsFilter = null;

    private readonly Dictionary<int, int> critmodifiers = new Dictionary<int, int>();

    public void Run()
    {

        foreach (var i in FlatMultiplierFilter)
        {

            int index = FlatMultiplierFilter.Get2(i).StatsIndex;

            if (critmodifiers.TryGetValue(index, out int currentsum))
            {

                critmodifiers[index] = currentsum + FlatMultiplierFilter.Get1(i).FlatCrit;

            }
            else
            {

                critmodifiers.Add(index, FlatMultiplierFilter.Get1(i).FlatCrit);

            }

        }



        foreach (var i in AllStatsFilter)
        {
            AllStatsFilter.GetEntity(i).Del<FlatCritComponent>();

            int index = AllStatsFilter.Get2(i).StatsIndex;

            if (critmodifiers.TryGetValue(index, out int critsum))
            {

                AllStatsFilter.GetEntity(i).Get<FlatCritComponent>().FlatCrit = critsum;

            }

        }

        critmodifiers.Clear();

    }

}
    
    


