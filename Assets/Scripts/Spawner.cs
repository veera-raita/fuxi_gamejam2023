using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject GameController;
    private bool GameHelper;
    private int waveN;
    float rndDelay;

    private void SpawnHandler()     //start all spawners
    {
        StartCoroutine(SpawnEnemyN());
        StartCoroutine(SpawnEnemyS());
        StartCoroutine(SpawnEnemyR());
        StartCoroutine(SpawnEnemyL());
    }

    private IEnumerator SpawnEnemyN()   //spawns enemies north
    {
        while (GameController.GetComponent<WaveController>().WaveRunning == true)
        {
            float rndX1 = Random.Range(-15.0f, 15.0f);
            int rnd = Random.Range(0, enemies.Length);
            Instantiate(enemies[rnd], new Vector3(rndX1, 15), enemies[rnd].transform.rotation);
            rndDelay = Random.Range(3.0f, 4.5f) - 0.1f * (float)waveN;
            if (rndDelay < 0.5f)
            {
                rndDelay = 0.5f;
            }
            yield return new WaitForSeconds(rndDelay);
        }
    }

    private IEnumerator SpawnEnemyS()   //south
    {
        while (GameController.GetComponent<WaveController>().WaveRunning == true)
        {
            float rndX2 = Random.Range(-15.0f, 15.0f);
            int rnd = Random.Range(0, enemies.Length);
            Instantiate(enemies[rnd], new Vector3(rndX2, -15), enemies[rnd].transform.rotation);
            rndDelay = Random.Range(3.0f, 4.5f) - 0.1f * (float)waveN;
            if (rndDelay < 0.5f)
            {
                rndDelay = 0.5f;
            }
            yield return new WaitForSeconds(rndDelay);
        }
    }

    private IEnumerator SpawnEnemyR()   //right
    {
        while (GameController.GetComponent<WaveController>().WaveRunning == true)
        {
            float rndY1 = Random.Range(-15.0f, 15.0f);
            int rnd = Random.Range(0, enemies.Length);
            Instantiate(enemies[rnd], new Vector3(15, rndY1), enemies[rnd].transform.rotation);
            rndDelay = Random.Range(3.0f, 4.5f) - 0.1f * (float)waveN;
            if (rndDelay < 0.5f)
            {
                rndDelay = 0.5f;
            }
            yield return new WaitForSeconds(rndDelay);
        }
    }

    private IEnumerator SpawnEnemyL()   //left
    {
        while (GameController.GetComponent<WaveController>().WaveRunning == true)
        {
            float rndY2 = Random.Range(-15.0f, 15.0f);
            int rnd = Random.Range(0, enemies.Length);
            Instantiate(enemies[rnd], new Vector3(-15, rndY2), enemies[rnd].transform.rotation);
            rndDelay = Random.Range(3.0f, 4.5f) - 0.1f * (float)waveN;
            if (rndDelay < 0.5f)
            {
                rndDelay = 0.5f;
            }
            yield return new WaitForSeconds(rndDelay);
        }
    }

    void Start()
    {
        Invoke("SpawnHandler", 2);
    }

    void Update()
    {
        GameController = GameObject.FindWithTag("GameController");
        if (GameController.GetComponent<WaveController>().WaveRunning == false)
        {
            CancelInvoke();
            GameHelper = true;
        }
        if (GameController.GetComponent<WaveController>().WaveRunning == true && GameHelper == true)    //don't fuck with GameHelper it will break shit
        {
            GameHelper = false;
            Invoke("SpawnHandler", 2);
        }
        waveN = GameController.GetComponent<WaveController>().WaveNumber;
    }
}