using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public struct UIDrawMesegesComponent
{
 
    public GameObject MessegeBoxPrefab;

    public Transform MessegeBoxParent;

    [System.NonSerialized]  
    public List<GameObject> MessegeBoxList;

}
