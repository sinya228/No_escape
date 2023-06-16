using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllItemStatsData", menuName = "StatsWithTiers/AllItemStats", order = 1)]
public class AllItemsStatsSO : ScriptableObject
{

    [SerializeField] private List<ItemBaseStatsSO> itemsbases;
    public List<ItemBaseStatsSO> ItemsBases => itemsbases;

}
