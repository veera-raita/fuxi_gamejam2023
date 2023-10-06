using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Vector2 m_mousePosition;

    public Transform m_projectileSpawnPoint;
    private Camera m_camera;

    private void Start()
    {
        m_camera = Camera.main;
    }

    void Update()
    {
        RotateToCursor();
    }

    private void RotateToCursor()
    {
        m_mousePosition = m_camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 t_cursorDirection = (m_mousePosition - (Vector2)transform.position).normalized;
        float t_angle = Mathf.Atan2(t_cursorDirection.y, t_cursorDirection.x) * Mathf.Rad2Deg - 90f;

        m_projectileSpawnPoint.transform.eulerAngles = new Vector3(0, 0, t_angle);
    }
}
