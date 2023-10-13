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
            int t_randomNumber = Random.Range(1, 101); // 1-100
            List<UpgradePoolItem> t_possibleItems = new();

            Debug.Log(t_randomNumber);

            foreach (UpgradePoolItem t_instance in t_upgradePool)
            {
                if (t_randomNumber <= t_instance.upgrade.dropChance)
                {
                    t_possibleItems.Add(t_instance);
                }
            }

            UpgradePoolItem t_poolItem = t_possibleItems[Random.Range(0, t_possibleItems.Count)];

            while (t_list.Contains(t_poolItem.upgrade))
            {
                t_poolItem = t_possibleItems[Random.Range(0, t_possibleItems.Count)];
            }

            t_list.Add(t_poolItem.upgrade);
        }

        return t_list;
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
