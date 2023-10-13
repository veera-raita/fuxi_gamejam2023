using System.Collections.Generic;
using UnityEngine;

public enum ItemTier
{
    Tier1,
    Tier2,
    Tier3
}

[CreateAssetMenu(menuName = "Upgrade", fileName = "New Upgrade")]
public class UpgradeBase : ScriptableObject
{
    public string upgradeName;
    public string upgradeDescription;
    public Sprite icon;
    public ItemTier itemTier = ItemTier.Tier1;

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