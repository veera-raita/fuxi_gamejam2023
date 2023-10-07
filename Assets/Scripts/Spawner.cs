using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int waveN;               //use this to slightly increase spawn speed every wave
                                    //maybe speed as well
    private void SpawnEnemyUp()
    {
        float rndX1 = Random.Range(-55.0f, 55.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(rndX1, 21), enemies[rnd].transform.rotation);
        Invoke("SpawnEnemyUp", Random.Range(1.5f, 3.0f));
    }
    private void SpawnEnemyDown()
    {
        float rndX2 = Random.Range(-55.0f, 55.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(rndX2, -21), enemies[rnd].transform.rotation);
        Invoke("SpawnEnemyDown", Random.Range(1.5f, 3.0f));
    }
    private void SpawnEnemyRight()
    {
        float rndY1 = Random.Range(-23.0f, 23.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(52, rndY1), enemies[rnd].transform.rotation);
        Invoke("SpawnEnemyRight", Random.Range(1.5f, 3.0f));
    }
    private void SpawnEnemyLeft()
    {
        float rndY2 = Random.Range(-23.0f, 23.0f);
        int rnd = Random.Range(0, enemies.Length);
        Instantiate(enemies[rnd], new Vector3(-52, rndY2), enemies[rnd].transform.rotation);
        Invoke("SpawnEnemyLeft", Random.Range(1.5f, 3.0f));
    }

    void Start()
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

    // Update is called once per frame
    void Update()
    {

    }
}
