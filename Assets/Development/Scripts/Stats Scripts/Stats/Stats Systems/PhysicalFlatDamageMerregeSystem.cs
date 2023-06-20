using Leopotam.Ecs;
using System.Collections.Generic;

sealed class PhysicalFlatDamageMerregeSystem : IEcsRunSystem
{

    private readonly EcsFilter<PhysicalFlatDamageComponent, StatGroopComponent>.Exclude<AllStatsComponent> FlatDamageFilter = null;

    private readonly EcsFilter<StatGroopComponent, AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    private readonly Dictionary<int, int> damagemodifiers = new Dictionary<int, int>();

    public void Run()
    {

        foreach (var i in FlatDamageFilter)
        {

            int index = FlatDamageFilter.Get2(i).StatsIndex;

            if (damagemodifiers.TryGetValue(index, out int currentsum))
            {

                damagemodifiers[index] = currentsum + FlatDamageFilter.Get1(i).FlatDamage;

            }
            else
            {

                damagemodifiers.Add(index, FlatDamageFilter.Get1(i).FlatDamage);

            }

        }



        foreach (var i in AllStatsFilter)
        {
            AllStatsFilter.GetEntity(i).Del<PhysicalFlatDamageComponent>();

            int index = AllStatsFilter.Get1(i).StatsIndex;

            if (damagemodifiers.TryGetValue(index, out int damagesum))
            {

                AllStatsFilter.GetEntity(i).Get<PhysicalFlatDamageComponent>().FlatDamage = damagesum;

            }

        }

        damagemodifiers.Clear();

    }

}
 




