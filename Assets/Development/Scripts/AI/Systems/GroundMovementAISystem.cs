using Assets.Development.Scripts.AI.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Development.Scripts.AI
{
   
    sealed class GroundMovementAISystem : IEcsRunSystem , IEcsInitSystem
    {
        private readonly EcsFilter<GroundMovementAIComponent> AI_Filter = null;

        public void Init()
        {
            foreach (var i in AI_Filter)
            {
                Debug.Log("пришли в AI");
                ref var gMovAIComponent = ref AI_Filter.Get1(i);
                if (gMovAIComponent.moveDistance == 0)
                {
                    gMovAIComponent.moveDistance = 20f;
                    Debug.Log("назначили дистанцию");
                }
                if (gMovAIComponent._position != gMovAIComponent._transform.position)
                {
                    gMovAIComponent._position = gMovAIComponent._transform.position;
                    Debug.Log("назначили положение");
                }
            }
        }
        public void Run()
        {
            Debug.Log("говно");
            foreach (var i in AI_Filter)
            {
                Debug.Log("пришли в AI");
                ref var gMovAIComponent = ref AI_Filter.Get1(i);

                Debug.Log(gMovAIComponent._position);
                Debug.Log(gMovAIComponent._transform.position);

                if (gMovAIComponent._position.x == gMovAIComponent._transform.position.x && gMovAIComponent._position.z == gMovAIComponent._transform.position.z)
                {
                    gMovAIComponent._position = RandomNavSphere(gMovAIComponent.moveDistance, gMovAIComponent._transform);
                    gMovAIComponent._navMeshAgent.SetDestination(gMovAIComponent._position);
                    Debug.Log("Изменили положение");
                }


            }
        }
        private Vector3 RandomNavSphere(float distance, Transform transform)
        {
            Vector3 randomDirection = Random.insideUnitSphere * distance;

            randomDirection += transform.position;

            NavMeshHit navHit;

            NavMesh.SamplePosition(randomDirection, out navHit, distance, -1);

            return navHit.position;
        }

    }
}
