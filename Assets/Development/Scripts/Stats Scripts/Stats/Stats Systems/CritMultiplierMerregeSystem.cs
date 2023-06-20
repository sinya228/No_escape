using Leopotam.Ecs;
using System.Collections.Generic;

sealed class CritMultiplierMerregeSystem : IEcsRunSystem
{
    
    private readonly EcsFilter<CritMultiplierComponent, StatGroopComponent>.Exclude<AllStatsComponent> CritMultiplierFilter = null;

    private readonly EcsFilter<StatGroopComponent, AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    private readonly Dictionary<int, int> critmodifiers = new Dictionary<int, int>();

    public void Run()
    {

        foreach (var i in CritMultiplierFilter)
        {

            int index = CritMultiplierFilter.Get2(i).StatsIndex;

            if (critmodifiers.TryGetValue(index, out int currentsum))
            {
                critmodifiers[index] = currentsum + CritMultiplierFilter.Get1(i).CritMultiplier;
            }
            else
            {
                critmodifiers.Add(index, CritMultiplierFilter.Get1(i).CritMultiplier);
            }

        }



        foreach (var i in AllStatsFilter)
        {
            AllStatsFilter.GetEntity(i).Del<CritMultiplierComponent>();

            int index = AllStatsFilter.Get1(i).StatsIndex;

            if (critmodifiers.TryGetValue(index, out int critsum))
            {
                AllStatsFilter.GetEntity(i).Get<CritMultiplierComponent>().CritMultiplier = critsum;
            }

        }

        critmodifiers.Clear();

    }

}



  
