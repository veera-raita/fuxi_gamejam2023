using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
            Camera.main.transform.position.z));
    }

    private void LateUpdate()
    {
        Vector3 t_viewPosition = transform.position;
        t_viewPosition.x = Mathf.Clamp(t_viewPosition.x, screenBounds.x, screenBounds.x * -1);
        t_viewPosition.y = Mathf.Clamp(t_viewPosition.y, screenBounds.y, screenBounds.y * -1);
        transform.position = t_viewPosition;
    }
}
