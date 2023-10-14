using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    [Space, Header("Upgrade Generation")]
    [SerializeField] private UpgradePool profile;
    [SerializeField] private int amountOfChoices = 3;
    private GameObject WaveYeag;

    [Space, Header("References")]
    public Transform[] spawnPoints = new Transform[3];
    [Space]
    [SerializeField] private List<UpgradeBase> choices;

    private UpgradeGenerator generator;

    private void Awake()
    {
        generator = GetComponent<UpgradeGenerator>();
        generator.SetCharacterPool(profile);
    }

    public void SpawnerCheck()
    {
        choices ??= new List<UpgradeBase>();

        choices.Clear();
        choices.AddRange(generator.GetRandom(amountOfChoices));

        GenerateUpgradeFromPool();

        SpawnDrops();
        WaveYeag = GameObject.FindWithTag("GameController");
        WaveYeag.GetComponent<WaveController>().wavecdhelp = true;
    }

    private void SpawnDrops()
    {
        for (int i = 0; i < choices.Count; i++)
        {
            UpgradeTest t_upgrade = spawnPoints[i].GetComponentInChildren<UpgradeTest>();
            t_upgrade.upgrade = choices[i];
        }
    }

    private void GenerateUpgradeFromPool()
    {
        choices = generator.GetRandom(amountOfChoices);
    }
}