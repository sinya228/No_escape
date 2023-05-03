using System;
using UnityEngine;

namespace MainPlayer
{
    [Serializable]
    public struct MovableComponent
    {
        public CharacterController characterController;
        public float speed;
    }
}