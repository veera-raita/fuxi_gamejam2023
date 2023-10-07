using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTest : MonoBehaviour
{
    public GameObject player;
    public UpgradeBase upgrade;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            upgrade.Create(player);
        }
    }
}
