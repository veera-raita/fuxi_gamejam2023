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

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioSource amogus;

    private WaveController controller;
    public GameObject goscreen;

    [SerializeField] private bool m_isDead = false;

    private void Start()
    {
        controller = FindObjectOfType<WaveController>();

        EndGame = FindObjectOfType<GameOver>();

        if (TryGetComponent(out characterStatHolder))
        {
            CurrentHealth = (int)characterStatHolder.MaximumHealth;
        }
        else
        {
            CurrentHealth = maximumHealth + controller.WaveNumber;
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

    public void Heal()
    {
        if (maximumHealth > CurrentHealth)
            CurrentHealth++;
    }

    public void Kill()
    {
        GameObject t_death = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(t_death, 5f);

        var source = FindObjectOfType<HealthUI>().GetComponent<AudioSource>();

        if (gameObject.CompareTag("player"))
        {
            EndGame.DoStuff();
            source.PlayOneShot(clip1, 1.0f);

            Destroy(gameObject);
        }

        
        source.PlayOneShot(clip2, 1.0f);
        Destroy(gameObject); 
    }
}
