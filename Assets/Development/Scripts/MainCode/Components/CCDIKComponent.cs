using System;
using UnityEngine;


[Serializable]
public struct CCDIKComponent
{
    [Header("Rotation Constrain")]
    public Vector3 HingeAxisRotation;
    public bool HasLimits;
    public Vector2 RotationAngleLimit;
    
    [Header("Joint")]
    public Transform JointTansform;



}
