using System;
using UnityEngine;


[Serializable]
public struct GroungCheckComponent
{

    public LayerMask GroundMask;
    public LayerMask WallMask;
    public Transform GrounCheckTransform;
    public float GrounCheckTransRadius;
    
    [NonSerialized]
    public bool isGrounded;


}
