using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private GameObject GameManager;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player");      //player is any object with the tag "player", be sure to tag player properly
        GameManager = GameObject.FindWithTag("GameController");
        speed *= Random.Range(0.5f, 1.5f) + (0.1f * GameManager.GetComponent<WaveController>().WaveNumber);
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            float realSpeed = speed * Time.deltaTime;        //randomize speeds a little bit
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, realSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), 
                collision.gameObject.GetComponent<Collider2D>());

            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            
        }
    }
}