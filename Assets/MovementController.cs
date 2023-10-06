using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public Transform shooting;

    [Space, Header("DEBUG")]
    [SerializeField] private Vector2 m_movementVector;
    [SerializeField] private Vector2 m_mousePosition;

    private void Start()
    {
        
    }

    private void Update()
    {
        m_movementVector.x = Input.GetAxisRaw("Horizontal");
        m_movementVector.y = Input.GetAxisRaw("Vertical");

        m_mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * m_movementVector);

        Vector2 t_orientation = (m_mousePosition - rb.position).normalized;
        float t_angle = Mathf.Atan2(t_orientation.y, t_orientation.x) * Mathf.Rad2Deg - 90f;
        shooting.eulerAngles = new Vector3(0, 0, t_angle);
    }
}
