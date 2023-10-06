using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player");      //player is any object with the tag "player", be sure to tag player properly
        speed = speed * Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float realSpeed = speed * Time.deltaTime;        //randomize speeds a little bit
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, realSpeed);
    }
}
