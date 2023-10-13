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

    public CharacterStat[] m_characterStatList = new CharacterStat[8];

    public float MovementSpeed => m_characterStatList[0].CalculatedFinalValue;
    public float MaximumHealth => m_characterStatList[1].CalculatedFinalValue;
    public float RateOfFire => m_characterStatList[2].CalculatedFinalValue;
    public float ProjectileDamage => m_characterStatList[3].CalculatedFinalValue;
    public float ProjectileRange => m_characterStatList[4].CalculatedFinalValue;
    public float ProjectileAmount => m_characterStatList[5].CalculatedFinalValue;
    public float ProjectileSpeed => m_characterStatList[6].CalculatedFinalValue;
    public float ProjectileSpread => m_characterStatList[7].CalculatedFinalValue;

    public void UpdateStatValues(StatModifier t_modifier)
    {
        int t_index = (int)t_modifier.statToBoost;
        m_characterStatList[t_index].AddModifier(t_modifier);
    }
}
