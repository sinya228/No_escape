using System;
using UnityEngine;



[Serializable]
public struct MovableComponent
{
    public Transform ObjectTransform;
    
    public CharacterController ObjectController;
    
    public float ObjectSpeed;
    
    public float GravityForce;

}