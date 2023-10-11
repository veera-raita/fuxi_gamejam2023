using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject GameController;
    private bool GameHelper;
    public int waveN;
    float rndDelay;                 //use this to slightly increase spawn speed every wave
                                    //maybe speed as well

    private void SpawnHandler()     //start all spawners
    {
        rndDelay = Random.Range(3.0f, 4.5f) - 0.1f * (float)waveN;
        if (rndDelay < 0.5f)
        {
            rndDelay = 0.5f;
        }
        Invoke("SpawnEnemyUp", rndDelay);
        rndDelay = Random.Range(3.0f, 4.5f);
        Invoke("SpawnEnemyDown", rndDelay);
        rndDelay = Random.Range(3.0f, 4.5f);
        Invoke("SpawnEnemyRight", rndDelay);
        rndDelay = Random.Range(3.0f, 4.5f);
        Invoke("SpawnEnemyLeft", rndDelay);
    }

    private void SpawnEnemyUp()
    {
        float rndX1 = Random.Range(-15.0f, 15.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(rndX1, 15), enemies[rnd].transform.rotation);
        rndDelay = Random.Range(3.0f, 4.5f) - 0.1f * (float)waveN;
        if (rndDelay < 0.5f)
        {
            rndDelay = 0.5f;
        }
        Invoke("SpawnEnemyUp", rndDelay);
    }
    private void SpawnEnemyDown()
    {
        float rndX2 = Random.Range(-15.0f, 15.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(rndX2, -15), enemies[rnd].transform.rotation);
        rndDelay = Random.Range(3.0f, 4.5f) - 0.1f * (float)waveN;
        if (rndDelay < 0.5f)
        {
            rndDelay = 0.5f;
        }
        Invoke("SpawnEnemyDown", rndDelay);
    }
    private void SpawnEnemyRight()
    {
        float rndY1 = Random.Range(-15.0f, 15.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(15, rndY1), enemies[rnd].transform.rotation);
        rndDelay = Random.Range(3.0f, 4.5f) - 0.1f * (float)waveN;
        if (rndDelay < 0.5f)
        {
            rndDelay = 0.5f;
        }
        Invoke("SpawnEnemyRight", rndDelay);
    }
    private void SpawnEnemyLeft()
    {
        float rndY2 = Random.Range(-15.0f, 15.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(-15, rndY2), enemies[rnd].transform.rotation);
        rndDelay = Random.Range(3.0f, 4.5f) - 0.1f * (float)waveN;
        if (rndDelay < 0.5f)
        {
            rndDelay = 0.5f;
        }
        Invoke("SpawnEnemyLeft", rndDelay);
    }

    void Start()
    {
        Invoke("SpawnHandler", 2);
    }

    // Update is called once per frame
    void Update()
    {
        GameController = GameObject.FindWithTag("GameController");
        if (GameController.GetComponent<WaveController>().WaveRunning == false)
        {
            CancelInvoke();
            GameHelper = true;
        }
        if (GameController.GetComponent<WaveController>().WaveRunning == true && GameHelper == true)    //tässä yritys saada viholliset spawnaamaan vain kun
        {                                                                                               //wave on oikeasti käynnissä. en tiedä kuin tärkeä GameHelper
            GameHelper = false;
            Invoke("SpawnHandler", 2);
        }
    }
}
