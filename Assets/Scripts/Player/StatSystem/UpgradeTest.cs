using UnityEngine;

public class UpgradeTest : MonoBehaviour
{
    public UpgradePool m_upgradePool;
    public UpgradeBase upgrade;

    private void Start()
    {
        upgrade =;
    }

    private void OnTriggerEnter2D(Collider2D t_collider)
    {
        if (t_collider.TryGetComponent(out MovementController t_stats))
        {
            upgrade.Create(t_collider.gameObject);
            //m_upgradePool.PoolItems.Remove(upgrade);
        }
    }
}
