using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    public float timer = 0;
    public SpriteRenderer HeadSprite;
    [SerializeField] private AudioClip splat;

    private void Start()
    {
        StartCoroutine(FlickerJekku());
    }

    private void Update()
    {
        HeadSprite = GetComponentInChildren<SpriteRenderer>();
        
        timer += Time.deltaTime;

        if (timer >= 15) { Destroy(gameObject); }
    }

    private IEnumerator FlickerJekku()
    {
        yield return new WaitForSeconds(12);
        HeadSprite.color = new Color(HeadSprite.color.r, HeadSprite.color.g, HeadSprite.color.b, 0.7f);
        yield return new WaitForSeconds(0.5f);
        HeadSprite.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        HeadSprite.color = new Color(HeadSprite.color.r, HeadSprite.color.g, HeadSprite.color.b, 0.7f);
        yield return new WaitForSeconds(0.5f);
        HeadSprite.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        HeadSprite.color = new Color(HeadSprite.color.r, HeadSprite.color.g, HeadSprite.color.b, 0.7f);
        yield return new WaitForSeconds(0.2f);
        HeadSprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        HeadSprite.color = new Color(HeadSprite.color.r, HeadSprite.color.g, HeadSprite.color.b, 0.7f);
        yield return new WaitForSeconds(0.2f);
        HeadSprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        HeadSprite.color = new Color(HeadSprite.color.r, HeadSprite.color.g, HeadSprite.color.b, 0.7f);
        yield return new WaitForSeconds(0.2f);
        HeadSprite.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && collision.gameObject.GetComponent<Health>().CurrentHealth < collision.gameObject.GetComponent<CharacterStatHolder>().MaximumHealth)
        {
            collision.GetComponent<Health>().AddHealth(1);
            Destroy(gameObject);
            AudioSource splatSource = GameObject.FindWithTag("canvas").GetComponent<AudioSource>();
            splatSource.PlayOneShot(splat, 1.0f);
        }
    }
}
