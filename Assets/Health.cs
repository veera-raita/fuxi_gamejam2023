using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maximumHealth = 50;

    public int CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = maximumHealth;
    }

    public void TakeDamage(int t_damage)
    {
        CurrentHealth -= t_damage;
        if (CurrentHealth <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);
    }
}
