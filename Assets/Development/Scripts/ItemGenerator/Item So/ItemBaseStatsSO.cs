using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemBaseData", menuName = "StatsWithTiers/ItemBaseStats", order = 1)]
public class ItemBaseStatsSO : ScriptableObject
{
    [SerializeField] private ItemBaseEnum itemtype;
    public ItemBaseEnum ItemType => itemtype;


    [SerializeField] private List<StatsSO> allitemstats;
    public List<StatsSO> AllItemStats => allitemstats;
}
