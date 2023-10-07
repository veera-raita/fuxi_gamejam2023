using UnityEngine;

public class CharacterStatHolder : MonoBehaviour
{
    public enum Stat
    {
        MovementSpeed,
        MaximumHealth,
        RateOfFire,
        ProjectileDamage,        
        ProjectileRange,
        ProjectileAmount,
        ProjectileSpeed,
        ProjectileSpread,
    }

    public CharacterStat[] m_stats = new CharacterStat[8];

    public float MovementSpeed => m_stats[0].CalculatedFinalValue;
    public float MaximumHealth => m_stats[1].CalculatedFinalValue;
    public float RateOfFire => m_stats[2].CalculatedFinalValue;
    public float ProjectileDamage => m_stats[3].CalculatedFinalValue;
    public float ProjectileRange => m_stats[4].CalculatedFinalValue;
    public float ProjectileAmount => m_stats[5].CalculatedFinalValue;
    public float ProjectileSpeed => m_stats[6].CalculatedFinalValue;
    public float ProjectileSpread => m_stats[7].CalculatedFinalValue;

    public void UpdateStatValues(StatModifier t_modifier)
    {
        int t_index = (int)t_modifier.statToBoost;
        m_stats[t_index].AddModifier(t_modifier);
    }
}
