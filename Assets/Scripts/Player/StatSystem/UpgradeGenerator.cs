using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeGenerator : MonoBehaviour
{
    [SerializeField] private List<UpgradePoolItem> m_upgradePool;
    [SerializeField] private List<UpgradeBase> m_ownedUpgrades;

    public void SetCharacterPool(UpgradePool t_profile)
    {
        m_upgradePool = GetFullPool(t_profile.PoolItems);
        m_ownedUpgrades = new List<UpgradeBase>();
    }

    

    public List<UpgradeBase> GetRandom(int t_amount)
    {
        return GetRandomFromPool(t_amount, m_upgradePool);
    }

    public List<UpgradeBase> GetRandomFromPool(int t_amount, List<UpgradePoolItem> t_upgradePool)
    {
        List<UpgradeBase> t_list = new();

        if (t_amount > m_upgradePool.Count)
            t_amount = m_upgradePool.Count;

        for (int i = 0; i < t_amount; i++)
        {
            UpgradePoolItem t_poolItem = t_upgradePool[Random.Range(0, t_upgradePool.Count)];



            while (t_list.Contains(t_poolItem.upgrade))
            {
                t_poolItem = t_upgradePool[Random.Range(0, t_upgradePool.Count)];
            }

            t_list.Add(t_poolItem.upgrade);
        }

        return t_list;
    }

    private UpgradeBase CalculateDropChance(UpgradeBase t_upgrade, List<UpgradeBase> t_list)
    {
        int t_randomNumber = Random.Range(1, 101); // 1-100
        int t_chance = 100;

        switch (t_upgrade.itemTier)
        {
            case (ItemTier.Tier1):
                t_chance = 100;
                break;
            case (ItemTier.Tier2):
                t_chance = 80;
                break;
            case (ItemTier.Tier3):
                t_chance = 60;
                break;
        }

        foreach (UpgradeBase t_instance in t_list)
        {
            if (t_randomNumber <= t_chance)
            {
                t_upgrade = t_instance;
            }
        }

        return t_upgrade;
    }

    public void AddToPool(List<UpgradeBase> t_upgradePool)
    {
        m_upgradePool.AddRange(GetFullPool(t_upgradePool));
    }

    public void RemoveFromPool(UpgradeBase t_upgrade)
    {
        UpgradePoolItem t_poolItem = m_upgradePool.Find(t_instance => t_instance.upgrade == t_upgrade);
        if (t_poolItem != null)
        {
            //m_upgradePool.Remove(t_poolItem);
            m_ownedUpgrades.Add(t_upgrade);
        }
    }

    private List<UpgradePoolItem> GetFullPool(List<UpgradeBase> t_upgradePool)
    {
        List<UpgradePoolItem> t_list = new();
        foreach (UpgradeBase t_upgrade in t_upgradePool)
        {
            UpgradePoolItem t_upgradePoolItem = new() { upgrade = t_upgrade };
            t_list.Add(t_upgradePoolItem);
        }

        return t_list;
    }
}
