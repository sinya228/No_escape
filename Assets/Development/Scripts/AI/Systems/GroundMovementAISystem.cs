using Assets.Development.Scripts.AI.Components;
using Leopotam.Ecs;
using UnityEditor.Timeline.Actions;
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
                ref var gMovAIComponent = ref AI_Filter.Get1(i);
                //if (gMovAIComponent.moveDistance == 0)
                //{
                //    gMovAIComponent.moveDistance = 20f;
                //    Debug.Log("назначили дистанцию");
                //}
                if (gMovAIComponent._position != gMovAIComponent._transform.position)
                {
                    gMovAIComponent._position = gMovAIComponent._transform.position;
                }
            }
        }
        public void Run()
        {
            foreach (var i in AI_Filter)
            {
                ref var gMovAIComponent = ref AI_Filter.Get1(i);

                Debug.Log(gMovAIComponent._position);
                Debug.Log(gMovAIComponent._transform.position);
                if (gMovAIComponent._position.x - 2 < gMovAIComponent._transform.position.x &&
                    gMovAIComponent._position.x + 2 > gMovAIComponent._transform.position.x &&
                    gMovAIComponent._position.z - 2 < gMovAIComponent._transform.position.z &&
                    gMovAIComponent._position.z + 2 > gMovAIComponent._transform.position.z 
                     )
                {
                    gMovAIComponent._position = RandomNavSphere(gMovAIComponent.moveDistance, gMovAIComponent._transform);
                    gMovAIComponent._navMeshAgent.SetDestination(gMovAIComponent._position);
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
