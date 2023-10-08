using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maximumHealth = 50;
    public GameObject deathEffect;
    public Transform damagePopup;
    public bool invincible = false;
    public int CurrentHealth { get; private set; }

    private CharacterStatHolder characterStatHolder;
    private GameOver EndGame;

    private ScoreScript score = new();

    public GameObject goscreen;

    [SerializeField] private bool m_isDead = false;

    private void Start()
    {
        EndGame = FindObjectOfType<GameOver>();

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

    public void Kill()
    {
        GameObject t_death = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(t_death, 5f);

        if (gameObject.CompareTag("player"))
        {
            EndGame.DoStuff();
            Destroy(gameObject);
        }

        Destroy(gameObject);

        
    }
}
