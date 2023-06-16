using Leopotam.Ecs;
using System;
using System.Collections.Generic;

sealed class RenderStatsUISystem : IEcsRunSystem
{

    private readonly EcsFilter<StatsToUIComponent> StatsUIFilter = null;
  
    private readonly EcsFilter<UIMessegesListComponent,UIComponent> MessegeListFilter = null;

    private readonly Dictionary<int, List<string>> messeges = new Dictionary<int, List<string>>();

 
    public void Run()
    {

        foreach (var i in StatsUIFilter)
        {
            ref var entity = ref StatsUIFilter.GetEntity(i);

            StatsUIFilter.Get1(i).Stats = new List<string>();

            StatsUIFilter.Get1(i).Name = "Default Name";
            StatsUIFilter.Get1(i).UIIndex = 9999;
          
            if (entity.Has<StatGroopComponent>())
            {
                StatsUIFilter.Get1(i).UIIndex = entity.Get<StatGroopComponent>().UIIndex;
                StatsUIFilter.Get1(i).Name = entity.Get<StatGroopComponent>().Name;
            }

            int index = StatsUIFilter.Get1(i).UIIndex;


            StatsUIFilter.Get1(i).Stats.Add(StatsUIFilter.Get1(i).Name.ToString());
            
            if (entity.Has<TotalHealthComponent>())
            {
                StatsUIFilter.Get1(i).Stats.Add(StatsUIFilter.Get1(i).Name.ToString() + " Have Total Health = " + entity.Get<TotalHealthComponent>().Health.ToString());
            }

            if (entity.Has<TotalMovementSpeedComponent>())
            {
                StatsUIFilter.Get1(i).Stats.Add(StatsUIFilter.Get1(i).Name.ToString() + " Have Total Movement Speed = " + entity.Get<TotalMovementSpeedComponent>().MovementSpeed.ToString());
            }
            


            if (entity.Has<FlatHealthComponent>()) 
            {
                StatsUIFilter.Get1(i).Stats.Add(StatsUIFilter.Get1(i).Name.ToString() + " Have Flat Health = " + entity.Get<FlatHealthComponent>().FlatHealth.ToString());
            }

            if (entity.Has<FlatMovementSpeedComponent>())
            {
                StatsUIFilter.Get1(i).Stats.Add(StatsUIFilter.Get1(i).Name.ToString() + " Have Flat Movement Speed = " + entity.Get<FlatMovementSpeedComponent>().FlatMovementSpeed.ToString());
            }

            if (entity.Has<IncreasedMovementSpeedComponent>())
            {
                StatsUIFilter.Get1(i).Stats.Add(StatsUIFilter.Get1(i).Name.ToString() + " Have Increased Movement Speed = " + entity.Get<IncreasedMovementSpeedComponent>().IncreasedMovementSpeed.ToString());
            }
            
            if (entity.Has<GlobalIncreaseDamageComponent>())
            {
                StatsUIFilter.Get1(i).Stats.Add(StatsUIFilter.Get1(i).Name.ToString() + " Have Global Increased Damage = " + entity.Get<GlobalIncreaseDamageComponent>().IncreaseDamage.ToString());
            }

            if (entity.Has<CritMultiplierComponent>())
            {
                StatsUIFilter.Get1(i).Stats.Add(StatsUIFilter.Get1(i).Name.ToString() + " Have Crit Multiplier = " + entity.Get<CritMultiplierComponent>().CritMultiplier.ToString());
            }


            if (messeges.TryGetValue(index, out List<string> messege))
            {
                messege.AddRange(StatsUIFilter.Get1(i).Stats);
            }
            else 
            {
                
                List<string> newmessege = new List<string>();

                newmessege.AddRange(StatsUIFilter.Get1(i).Stats);

                messeges.Add(index, newmessege);

            }

            StatsUIFilter.GetEntity(i).Del<StatsToUIComponent>();

        }

    

        foreach (var i in MessegeListFilter)
        {
            
            int index = MessegeListFilter.Get2(i).UIIndex;

            MessegeListFilter.Get1(i).MessegeList.Clear();

            if (messeges.TryGetValue(index, out List<string> messege))
            {
                
                MessegeListFilter.Get1(i).MessegeList.AddRange(messege);
            
            }

        }

        messeges.Clear();

    }


}