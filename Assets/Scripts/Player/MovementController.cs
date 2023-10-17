using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float screenPadding = 0;
    [Space, Header("DEBUG")]
    [SerializeField] private Vector2 m_movementVector;
    [SerializeField] private float m_currentSpeed;

    private Health m_health;
    private CharacterStatHolder m_characterStatHolder;
    private Rigidbody2D rb;

    public UnityAction onDamaged;

    [SerializeField] private SpriteRenderer PlayerSprite;

    private GameOver EndGame;

    public bool IsDead { get; private set; }

    private void Start()
    {
        m_characterStatHolder = GetComponent<CharacterStatHolder>();
        rb = GetComponent<Rigidbody2D>();

        m_health = GetComponent<Health>();

        EndGame = FindObjectOfType<GameOver>();

        m_health.OnDie += OnDie;
        m_health.OnDamaged += OnDamaged;
    }

    private void Update()
    {
        m_movementVector.x = Input.GetAxisRaw("Horizontal");
        m_movementVector.y = Input.GetAxisRaw("Vertical");

        Vector3 t_minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 t_maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, t_minScreenBounds.x +
            screenPadding, t_maxScreenBounds.x - screenPadding), Mathf.Clamp(transform.position.y, t_minScreenBounds.y + 
            screenPadding, t_maxScreenBounds.y - screenPadding));

        CalculateSpeed();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + m_currentSpeed * Time.fixedDeltaTime * m_movementVector);     
    }

    private void OnDamaged(int t_damage, GameObject t_damageSource)
    {
        if (t_damageSource && t_damageSource.GetComponent<EnemyMovement>())
        {
            onDamaged?.Invoke();

            m_health.Invincible = true;
            StartCoroutine(IFrames());
            StartCoroutine(SpriteFlicker());
        }
    }

    private IEnumerator IFrames()
    {
        yield return new WaitForSeconds(1);

        m_health.Invincible = false;
    }

    private IEnumerator SpriteFlicker()
    {
        PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0.7f);
        yield return new WaitForSeconds(0.2f);
        PlayerSprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0.7f);
        yield return new WaitForSeconds(0.2f);
        PlayerSprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0.7f);
        yield return new WaitForSeconds(0.1f);
        PlayerSprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0.7f);
        yield return new WaitForSeconds(0.1f);
        PlayerSprite.color = Color.white;
    }

    private void OnDie()
    {
        IsDead = true;

        EndGame.DoStuff();
        Destroy(gameObject);
    }

    private void CalculateSpeed()
    {
        m_currentSpeed = m_characterStatHolder.MovementSpeed;
    }
}