using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeTooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemDescriptionText;

    public GameObject panel;

    private void Awake()
    {
        HideTooltip();
    }

    public void ShowTooltip(UpgradeBase t_upgrade)
    {
        itemNameText.text = t_upgrade.upgradeName;
        itemDescriptionText.text = t_upgrade.upgradeDescription;
        panel.SetActive(true);
    }

    public void HideTooltip()
    {
        panel.SetActive(false);
    }
}
