using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Description : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public UpgradeBase upgrade;

    private void Update()
    {
        if (upgrade != null)
        {
            ShowDesc();
        }
        else
        {
            HideDesc();
        }

        nameText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.upgradeDescription;
    }

    public void ShowDesc()
    {
        gameObject.SetActive(true);
    }

    public void HideDesc()
    {
        gameObject.SetActive(false);
    }
}
