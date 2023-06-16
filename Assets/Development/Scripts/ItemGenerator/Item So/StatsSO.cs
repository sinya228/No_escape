using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SatsData", menuName = "StatsWithTiers/Stats", order = 1)]


public class StatsSO : ScriptableObject
{
    [SerializeField] private StatTypeEnum  stattype;
    public StatTypeEnum StatType => stattype;


    [SerializeField] private List<Vector2Int> statstiervalue;
    public List<Vector2Int> StatsTierValue => statstiervalue;

}
