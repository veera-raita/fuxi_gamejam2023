using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOnHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gobjScore = GameObject.FindWithTag("score");     //SCORE OBJECT NEEDS THIS TAG
        if (other.gameObject.tag == "enemy")                        //ENEMIES NEED THIS TAG
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (gobjScore != null)
            {
                gobjScore.GetComponent<ScoreScript>().ScoreCount++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
