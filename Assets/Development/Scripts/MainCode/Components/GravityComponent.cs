using System;
using UnityEngine;

[Serializable]
public struct GravityComponent
{

    public Transform GravityDirection;   
    public float GravityScale;
    public Vector2 GravityVelocityLim;

    [NonSerialized]
    public float GravityVelocity;

}

