using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    public float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 15) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && collision.gameObject.GetComponent<Health>().CurrentHealth < collision.gameObject.GetComponent<CharacterStatHolder>().MaximumHealth)
        {
            collision.GetComponent<Health>().AddHealth(1);
            Destroy(gameObject);
        }
    }
}
