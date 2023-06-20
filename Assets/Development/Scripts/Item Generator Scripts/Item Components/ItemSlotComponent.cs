using System;
using UnityEngine;

[Serializable]
public struct ItemSlotComponent
{
    public ItemBaseEnum ItemSlotType;
    
    public MessegeBoxFoarmPrefab FoarmPrefab;
    
    public Transform Parent;
    
    public bool EmptySlot;

    [System.NonSerialized]
    public string HoldedItemName;

}
