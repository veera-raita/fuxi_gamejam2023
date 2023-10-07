using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private GameObject GameManager;
    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player");      //player is any object with the tag "player", be sure to tag player properly
        GameManager = GameObject.FindWithTag("GameController");
        speed = speed + (0.1f * (float)GameManager.GetComponent<WaveController>().WaveNumber);
        speed = speed * Random.Range(1.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float realSpeed = speed * Time.deltaTime;        //randomize speeds a little bit
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, realSpeed);
    }
}
