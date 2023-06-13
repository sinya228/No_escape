using UnityEngine;

[CreateAssetMenu(fileName = "FlatDamageData", menuName = "StatsData")]

public class FlatDamageSO : ScriptableObject
{

    [SerializeField] private float _flatdamage;
    public float FlatDamage { get => _flatdamage; }


}
