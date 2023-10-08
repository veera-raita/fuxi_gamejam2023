using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private const float DISAPPEAR_TIMER_MAX = 1;

    [SerializeField] private float disappearTimer;
    private TextMeshPro textMesh;
    private Color textColor;

    private Vector3 moveVector;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(int t_damageAmount)
    {
        textMesh.SetText(t_damageAmount.ToString());
        textColor = textMesh.color;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        moveVector = new Vector3(1, 1) * 30f;
    }

    private void Update()
    {
        float moveYSpeed = 2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        if(disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            float increaseScale = 1f;
            transform.localScale += Vector3.one * increaseScale * Time.deltaTime;
        }
        else
        {
            float decreaseScale = 1f;
            transform.localScale -= Vector3.one * decreaseScale * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
