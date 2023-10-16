using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private GameObject GameManager;
    public float speed = 2.0f;

    public GameObject deathEffect;

    public AudioClip clip2;

    public UnityAction onDamaged;

    private Health m_health;

    void Start()
    {
        m_health = GetComponent<Health>();

        m_health.OnDie += OnDie;
        m_health.OnDamaged += OnDamaged;

        player = GameObject.FindWithTag("player");      //player is any object with the tag "player", be sure to tag player properly
        GameManager = GameObject.FindWithTag("GameController");
        speed *= Random.Range(0.5f, 1.5f) + (0.1f * GameManager.GetComponent<WaveController>().WaveNumber);
    }

    void Update()
    {
        if (player != null)
        {
            float realSpeed = speed * Time.deltaTime;        //randomize speeds a little bit
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, realSpeed);
        }
    }

    private void OnDamaged(int t_damage, GameObject t_damageSource)
    {
        if (t_damageSource && !t_damageSource.GetComponent<EnemyMovement>())
        {
            onDamaged?.Invoke();
        }
    }

    private void OnDie()
    {
        GameObject t_death = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(t_death, 5f);


        AudioSource source = FindObjectOfType<HealthUI>().GetComponent<AudioSource>();
        source.PlayOneShot(clip2, 1.0f);
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            //Physics2D.IgnoreCollision(GetComponent<Collider2D>(),
              //  collision.gameObject.GetComponent<Collider2D>());

            collision.gameObject.GetComponent<Health>().TakeDamage(1, gameObject);            
        }
    }
}