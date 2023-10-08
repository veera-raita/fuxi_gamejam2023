using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDescription : MonoBehaviour
{
    public Description description;
    public UpgradeTest test;

    private void Update()
    {
        test = GetComponentInChildren<UpgradeTest>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterStatHolder>())
        {
            description.upgrade = test.upgrade;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterStatHolder>())
        {
            description.upgrade = null;
        }
    }
}
