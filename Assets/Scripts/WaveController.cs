using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int WaveNumber;
    public float WaveCountdown;
    public float WaveTimer;
    public bool WaveRunning;

    private UpgradeSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<UpgradeSpawner>();

        WaveNumber = 0;
        StartCoroutine(Wave());
    }

    public void StartWave()
    {
        StartCoroutine(Wave());
    }

    public IEnumerator Wave()
    {
        yield return new WaitForSeconds(WaveCountdown);
        WaveRunning = true;
        WaveNumber++;
        WaveTimer = 10.0f + (5.0f * WaveNumber);
        yield return new WaitForSeconds(WaveTimer);
        //Debug.Log("yeah " + Time.time);
        WaveRunning = false;
        //tähän fanfaari sfx
        MassMurderScript();
        spawner.SpawnerCheck();
    }

    private void MassMurderScript()
    {
        var enemies = FindObjectsOfType<EnemyMovement>();

        foreach(var health in enemies)
        {
            health.GetComponent<Health>().TakeDamage(9999);
        }
    }
}
