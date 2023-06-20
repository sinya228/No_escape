using Leopotam.Ecs;
using System.Collections.Generic;

sealed class FlatHealthMerrigeSystem : IEcsRunSystem
{
    private readonly EcsFilter<FlatHealthComponent,StatGroopComponent>.Exclude<AllStatsComponent> FlatHealthFilter = null;

    private readonly EcsFilter<StatGroopComponent, AllStatsComponent, StatsUpdateEvent> AllStatsFilter = null;

    private readonly Dictionary<int, int> healthmodifiers = new Dictionary<int, int>();

    public void Run()
    {

        foreach (var i in FlatHealthFilter)
        {
         
            int index = FlatHealthFilter.Get2(i).StatsIndex;

            if (healthmodifiers.TryGetValue(index, out int currentsum))
            {
                healthmodifiers[index] = currentsum + FlatHealthFilter.Get1(i).FlatHealth;
            }
            else
            {
                healthmodifiers.Add(index, FlatHealthFilter.Get1(i).FlatHealth);
            }
        
        }



        foreach (var i in AllStatsFilter)
        {
            AllStatsFilter.GetEntity(i).Del<FlatHealthComponent>();

            int index = AllStatsFilter.Get1(i).StatsIndex;
            
            if (healthmodifiers.TryGetValue(index, out int healthsum))
            {
                AllStatsFilter.GetEntity(i).Get<FlatHealthComponent>().FlatHealth = healthsum;                             
            }
       
        }

        healthmodifiers.Clear();

    }

}