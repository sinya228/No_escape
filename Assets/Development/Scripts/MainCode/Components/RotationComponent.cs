using System;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public struct RotationComponent
{
    [Header("Rotation Constrain")]
    public bool ConstrainX;
    public bool ConstrainY;
    public bool ConstrainZ;

    


    public Transform ObjectTransform;

    public float ObjectRotationSpeed;


    [NonSerialized]
    public Vector3 RotateDirection;

}
