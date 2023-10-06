using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Space, Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 5f;
    [Space, Header("DEBUG")]
    [SerializeField] private Vector2 m_movementVector;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        m_movementVector.x = Input.GetAxisRaw("Horizontal");
        m_movementVector.y = Input.GetAxisRaw("Vertical");      
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * m_movementVector);     
    }
}
