using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public TMP_Text healthText;
    private CharacterStatHolder characterStatHolder;
    private Health health;

    void Start()
    {
        characterStatHolder = FindObjectOfType<CharacterStatHolder>();
        health = characterStatHolder.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.CurrentHealth.ToString() + "/" + characterStatHolder.MaximumHealth.ToString();
    }
}
