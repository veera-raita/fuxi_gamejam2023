using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject GameController;
    private bool GameHelper;
    public int waveN;               //use this to slightly increase spawn speed every wave
                                    //maybe speed as well

    private void SpawnHandler()     //start all spawners
    {
        float rndDelay = Random.Range(1.5f, 3.0f);
        Invoke("SpawnEnemyUp", rndDelay);
        rndDelay = Random.Range(1.5f, 3.0f);
        Invoke("SpawnEnemyDown", rndDelay);
        rndDelay = Random.Range(1.5f, 3.0f);
        Invoke("SpawnEnemyRight", rndDelay);
        rndDelay = Random.Range(1.5f, 3.0f);
        Invoke("SpawnEnemyLeft", rndDelay);
    }

    private void SpawnEnemyUp()
    {
        float rndX1 = Random.Range(-15.0f, 15.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(rndX1, 15), enemies[rnd].transform.rotation);
        Invoke("SpawnEnemyUp", Random.Range(1.5f, 3.0f));
    }
    private void SpawnEnemyDown()
    {
        float rndX2 = Random.Range(-15.0f, 15.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(rndX2, -15), enemies[rnd].transform.rotation);
        Invoke("SpawnEnemyDown", Random.Range(1.5f, 3.0f));
    }
    private void SpawnEnemyRight()
    {
        float rndY1 = Random.Range(-13.0f, 13.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(15, rndY1), enemies[rnd].transform.rotation);
        Invoke("SpawnEnemyRight", Random.Range(1.5f, 3.0f));
    }
    private void SpawnEnemyLeft()
    {
        float rndY2 = Random.Range(-13.0f, 13.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(-15, rndY2), enemies[rnd].transform.rotation);
        Invoke("SpawnEnemyLeft", Random.Range(1.5f, 3.0f));
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
