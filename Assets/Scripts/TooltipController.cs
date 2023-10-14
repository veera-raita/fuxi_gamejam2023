using UnityEngine;

public class TooltipController : MonoBehaviour
{
    private UpgradeTooltip tooltip;
    public UpgradeTest m_handler;
    private UpgradeBase m_upgrade;

    private void Start()
    {
        tooltip = FindObjectOfType<UpgradeTooltip>();
    }

    private void Update()
    {
        m_upgrade = m_handler.upgrade;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (m_upgrade && collision.gameObject.CompareTag("player"))
        {
            tooltip.ShowTooltip(m_upgrade);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (m_upgrade && collision.gameObject.CompareTag("player"))
        {
            tooltip.HideTooltip();
        }
    }
}