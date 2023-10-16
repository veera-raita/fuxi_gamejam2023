using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && collision.gameObject.GetComponent<Health>().CurrentHealth < collision.gameObject.GetComponent<CharacterStatHolder>().MaximumHealth)
        {
            collision.GetComponent<Health>().AddHealth(1);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
