﻿using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Development.Entity
{
    sealed class EntityInitializeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeEntityRequestComponent> initFilter = null;

        public void Run()
        {
            foreach (var i in initFilter)
            {
                ref var entity = ref initFilter.GetEntity(i);
                ref var request = ref initFilter.Get1(i);

                request.entityReference._entity = entity;
                entity.Del<InitializeEntityRequestComponent>();
                Debug.Log("работает");
            }
        }
    }
}
