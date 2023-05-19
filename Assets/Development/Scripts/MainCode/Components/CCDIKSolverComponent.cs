using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct CCDIKSolverComponent
{

    public List<CCDIKComponent> IKComponents;
   
    public Transform IKTarget;

    public Transform IKEndEffector;

    [NonSerialized]
    public int IKCompCount;


}

