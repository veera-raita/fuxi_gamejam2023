using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    [Space, Header("Upgrade Generation")]
    [SerializeField] private UpgradePool profile;
    [SerializeField] private int amountOfChoices = 3;
    [SerializeField] private bool readyToSpawn = false;
    [SerializeField] private bool gameHelper;

    [Space, Header("References")]
    public UpgradeTest itemPrefab;
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
    }

    private void SpawnDrops()
    {
        for (int i = 0; i < choices.Count; i++)
        {
            UpgradeTest t_upgrade = Instantiate(itemPrefab, spawnPoints[i].transform.position, Quaternion.identity);
            t_upgrade.transform.parent = spawnPoints[i].transform;
            t_upgrade.upgrade = choices[i];
        }
    }

    private void GenerateUpgradeFromPool()
    {
        choices = generator.GetRandom(amountOfChoices);
    }
}
