using UnityEngine;
public partial class EcsGameStartup
{
    internal struct MovableComponent
    {
        public CharacterController CharacterController;
        public float Speed;
    }
}
