using System;
using UnityEngine.AI;
using UnityEngine;

namespace Assets.Development.Scripts.AI.Components
{
    [Serializable]
    public struct GroundMovementAIComponent
    {
        public NavMeshAgent _navMeshAgent;
        public float moveDistance;
        public Transform _transform;
        public Vector3 _position;

    }
}
