using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public int damage;
    public float speed;

    public void Initialize(int t_damage, int t_speed)
    {
        damage = t_damage;
        speed = t_speed;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
    }

    private void OnTriggerEnter2D(Collider2D t_collider)
    {
        if (t_collider.TryGetComponent(out Health t_health))
        {
            t_health.TakeDamage(damage);
        }

        Debug.Log("amogus");
    }
}
