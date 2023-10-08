using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDescription : MonoBehaviour
{
    private Description description;
    private UpgradeTest test;

    private void Start()
    {
        description = FindObjectOfType<Description>();
        test = GetComponentInChildren<UpgradeTest>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterStatHolder>())
        {
            description.upgrade = test.upgrade;
        }
        else
        {
            description.upgrade = null;
        }
    }
}
