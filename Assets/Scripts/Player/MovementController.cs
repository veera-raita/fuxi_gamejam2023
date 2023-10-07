using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
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
