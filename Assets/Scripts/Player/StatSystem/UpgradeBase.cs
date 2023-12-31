using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade", fileName = "New Upgrade")]
public class UpgradeBase : ScriptableObject
{
    public string upgradeName;
    public string upgradeDescription;
    public Sprite icon;
    public float dropChance;
    public Color glimmerColor;

    public List<StatModifier> m_statModifiers = new();

    public void Create(GameObject t_target)
    {
        for (int i = 0; i < m_statModifiers.Count; i++)
        {
            StatModifier t_modifier = m_statModifiers[i];
            t_target.GetComponent<CharacterStatHolder>().UpdateStatValues(t_modifier);
        }
    }
}