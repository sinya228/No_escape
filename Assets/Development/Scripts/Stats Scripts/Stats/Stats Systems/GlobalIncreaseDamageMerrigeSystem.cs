using Leopotam.Ecs;
using System.Collections.Generic;

sealed class GlobalIncreaseDamageMerrigeSystem : IEcsRunSystem
{
 
    private readonly EcsFilter<GlobalIncreaseDamageComponent, StatGroopComponent>.Exclude<AllStatsComponent> IncreaseDamageFilter = null;

    private readonly EcsFilter<StatGroopComponent, AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    private readonly Dictionary<int, int> damagemodifiers = new Dictionary<int, int>();

    public void Run()
    {

        foreach (var i in IncreaseDamageFilter)
        {

            int index = IncreaseDamageFilter.Get2(i).StatsIndex;

            if (damagemodifiers.TryGetValue(index, out int currentsum))
            {

                damagemodifiers[index] = currentsum + IncreaseDamageFilter.Get1(i).IncreaseDamage;

            }
            else
            {

                damagemodifiers.Add(index, IncreaseDamageFilter.Get1(i).IncreaseDamage);

            }

        }



        foreach (var i in AllStatsFilter)
        {
            AllStatsFilter.GetEntity(i).Del<GlobalIncreaseDamageComponent>();

            int index = AllStatsFilter.Get1(i).StatsIndex;

            if (damagemodifiers.TryGetValue(index, out int damagesum))
            {

                AllStatsFilter.GetEntity(i).Get<GlobalIncreaseDamageComponent>().IncreaseDamage = damagesum;

            }

        }

        damagemodifiers.Clear();

    }

}



