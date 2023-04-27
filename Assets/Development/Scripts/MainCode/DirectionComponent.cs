using UnityEngine;
public partial class EcsGameStartup
{
    sealed partial class MovementSystem
    {
        internal struct DirectionComponent
        {
            public Vector3 Direction;
        }
    }
}
