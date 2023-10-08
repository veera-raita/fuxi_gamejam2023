using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStats : MonoBehaviour
{
    private CharacterStatHolder characterStatHolder;
    [SerializeField] private TMP_Text dmg_Text;
    [SerializeField] private TMP_Text frate_Text;
    [SerializeField] private TMP_Text coins_Text;
    [SerializeField] private TMP_Text sprd_Text;
    [SerializeField] private TMP_Text spd_Text;
    [SerializeField] private TMP_Text rng_Text;
    [SerializeField] private TMP_Text pwr_Text;

    // Start is called before the first frame update
    void Start()
    {
        characterStatHolder = FindAnyObjectByType<CharacterStatHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        dmg_Text.text = characterStatHolder.ProjectileDamage.ToString();
        frate_Text.text = characterStatHolder.RateOfFire.ToString();
        coins_Text.text = characterStatHolder.ProjectileAmount.ToString();
        sprd_Text.text = characterStatHolder.ProjectileSpread.ToString();
        spd_Text.text = characterStatHolder.MovementSpeed.ToString();
        rng_Text.text = characterStatHolder.ProjectileSpeed.ToString();
        pwr_Text.text = characterStatHolder.ProjectileSpeed.ToString();
    }
}
