using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    private int damage;
    private float range;
    private float speed;

    public GameObject particle;

    private void Start()
    {

    }

    public void Initialize(int t_damage, int t_range, int t_speed)
    {
        damage = t_damage;
        range = t_range;
        speed = t_speed;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
        Destroy(gameObject, range);
    }

    private void OnTriggerEnter2D(Collider2D t_collider)
    {
        if (!t_collider.gameObject.CompareTag("player"))
        {
            if (t_collider.TryGetComponent(out Health t_health))
            {
                GameObject t_particle = Instantiate(particle, t_collider.transform.position, Quaternion.identity);
                Destroy(t_particle, 1f);
                t_health.TakeDamage(damage);
                Destroy(gameObject);
            }
        }        
    }
}
