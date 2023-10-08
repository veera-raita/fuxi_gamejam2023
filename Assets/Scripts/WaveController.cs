using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int WaveNumber;
    public float WaveCountdown = 3;
    public float WaveTimer;
    public bool WaveRunning;
    private float waver;
    public bool wavecdhelp;

    public TMP_Text WaveN;


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
        waver = WaveCountdown;
        WaveTimer = 15.0f + (5.0f * WaveNumber);
        yield return new WaitForSeconds(WaveTimer);
        //Debug.Log("yeah " + Time.time);
        WaveRunning = false;
        wavecdhelp = false;
        MassMurderScript();
        spawner.SpawnerCheck();
    }

    private void MassMurderScript()
    {
        var enemies = FindObjectsOfType<EnemyMovement>();

        foreach(var health in enemies)
        {
            Destroy(health.gameObject);
        }
    }

    private void Update()
    {
        WaveN.text = WaveNumber.ToString();


    }
}
