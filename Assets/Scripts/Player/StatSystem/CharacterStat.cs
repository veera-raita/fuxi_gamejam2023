using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStat
{
    [SerializeField] private string name;
    [SerializeField] private float baseValue;
    [SerializeField] private float minimumValue, maximumValue;

    protected float totalValue;
    public virtual float CalculatedFinalValue
    {
        get { totalValue = CalculateFinalValue(); return totalValue; }
    }

    protected readonly List<StatModifier> m_statModifiers;

    public CharacterStat()
    {
        m_statModifiers = new List<StatModifier>();
    }

    public CharacterStat(float t_baseValue)
    {
        baseValue = t_baseValue;        
    }

    public void AddModifier(StatModifier t_modifier)
    {
        m_statModifiers.Add(t_modifier);
        m_statModifiers.Sort(CompareModifierOrder);
    }

    public bool RemoveModifier(StatModifier t_modifier)
    {
        return m_statModifiers.Remove(t_modifier);
    }

    private int CompareModifierOrder(StatModifier t_modifier1, StatModifier t_modifier2)
    {
        if (t_modifier1.order < t_modifier2.order)
        {
            return -1;
        }
        else if (t_modifier1.order > t_modifier2.order)
        {
            return 1;
        }

        return 0;
    }

    private float CalculateFinalValue()
    {
        float t_finalValue = baseValue;

        for (int i = 0; i < m_statModifiers.Count; i++)
        {
            StatModifier t_modifier = m_statModifiers[i];

            if (t_modifier.method == StatModifierMethod.Flat)
            {
                t_finalValue += t_modifier.value;
            }
            else if (t_modifier.method == StatModifierMethod.Percentage)
            {
                t_finalValue *= 1 + t_modifier.value;
            }

            t_finalValue = Mathf.Clamp(t_finalValue, minimumValue, maximumValue);
        }

        return (float)System.Math.Round(t_finalValue, 4);
    }
}