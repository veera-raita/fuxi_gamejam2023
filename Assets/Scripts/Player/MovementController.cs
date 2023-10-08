using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float screenPadding = 0;
    [Space, Header("DEBUG")]
    [SerializeField] private Vector2 m_movementVector;
    [SerializeField] private float m_currentSpeed;

    private CharacterStatHolder m_characterStatHolder;
    private Rigidbody2D rb;

    private void Start()
    {
        m_characterStatHolder = GetComponent<CharacterStatHolder>();
        rb = GetComponent<Rigidbody2D>();
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

    private void CalculateSpeed()
    {
        m_currentSpeed = m_characterStatHolder.MovementSpeed;
    }
}