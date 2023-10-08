using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Description : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;

    public GameObject description;
    public UpgradeBase upgrade;

    private void Start()
    {
        HideDesc();
    }

    private void Update()
    {
        nameText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.upgradeDescription;
        /*
        if (upgrade != null)
        {
            ShowDesc();
        }
        
        if (upgrade == null)
        {
            HideDesc();
        }
        */
    }

    public void ShowDesc()
    {
        description.SetActive(true);
    }

    public void HideDesc()
    {
        description.SetActive(false);
    }
}
