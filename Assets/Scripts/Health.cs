using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Space, Header("Health Settings")]
    [SerializeField] public int maximumHealth = 50;

    public UnityAction<int, GameObject> OnDamaged;
    public UnityAction<int> OnHealed;
    public UnityAction OnDie;

    public int CurrentHealth { get; set; }
    public bool Invincible { get; set; }
    
    public Transform damagePopup;

    private CharacterStatHolder characterStatHolder;

    public AudioSource amogus;

    private WaveController controller;

    public bool CanAddHealth;

    public bool m_isDead;

    private void Start()
    {
        controller = FindObjectOfType<WaveController>();

        if (TryGetComponent(out characterStatHolder))
        {
            CurrentHealth = (int)characterStatHolder.MaximumHealth;
        }
        else
        {
            CurrentHealth = maximumHealth + (2 * controller.WaveNumber);
        }
    }

    private void Update()
    {
        if (TryGetComponent(out characterStatHolder) && characterStatHolder.MaximumHealth < CurrentHealth)
        {
            CurrentHealth = (int)characterStatHolder.MaximumHealth;
            CanAddHealth = false;
        }
        else
        {
            CanAddHealth = CurrentHealth < maximumHealth;
        }
    }

    public void TakeDamage(int t_damage, GameObject t_damageSource)
    {
        if (Invincible) { return; }

        Transform t_damagePopup = Instantiate(damagePopup, transform.position, Quaternion.identity);
        t_damagePopup.GetComponent<DamagePopup>().Setup(t_damage);

        if (!m_isDead)
        {
            CurrentHealth -= t_damage;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maximumHealth);

            OnDamaged?.Invoke(t_damage, t_damageSource);

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                HandleDeath();
            }
        }        
    }

    public void AddHealth(int t_amount)
    {
        if (CurrentHealth < maximumHealth)
        {
            CurrentHealth += t_amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maximumHealth);
        }

        if (CurrentHealth > maximumHealth)
        {
            CurrentHealth = maximumHealth;
        }
    }

    public void Kill()
    {
        CurrentHealth = 0;
        OnDamaged?.Invoke(maximumHealth, null);

        HandleDeath();
    }

    private void HandleDeath()
    {
        if (m_isDead) { return; }

        if (CurrentHealth <= 0f)
        {
            m_isDead = true;
            OnDie?.Invoke();
        }
    }
}
