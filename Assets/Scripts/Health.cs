using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maximumHealth = 50;
    public Transform damagePopup;
    public bool invincible = false;
    public int CurrentHealth { get; private set; }

    private CharacterStatHolder characterStatHolder;

    private void Start()
    {
        if (TryGetComponent(out characterStatHolder))
        {
            CurrentHealth = (int)characterStatHolder.MaximumHealth;
        }
        else
        {
            CurrentHealth = maximumHealth;
        }        
    }

    public void TakeDamage(int t_damage)
    {
        if (!invincible)
        {
            Transform t_damagePopup = Instantiate(damagePopup, transform.position, Quaternion.identity);
            t_damagePopup.GetComponent<DamagePopup>().Setup(t_damage);

            CurrentHealth -= t_damage;
            if (CurrentHealth <= 0)
            {
                Kill();
            }
        }        
    }

    private void Kill()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);
    }
}
