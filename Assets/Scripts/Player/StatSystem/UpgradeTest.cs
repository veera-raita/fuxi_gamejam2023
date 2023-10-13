using UnityEngine;
using UnityEngine.Events;

public class UpgradeTest : MonoBehaviour
{
    public UpgradeBase upgrade;    
    public GameObject WaveMeme;

    public UnityAction upgradeCheck;

    private UpgradeGenerator generator;

    public AudioClip clip;
    public AudioSource source;
    private WaveController waveController;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        waveController = FindObjectOfType<WaveController>();
        generator = FindObjectOfType<UpgradeGenerator>();
    }

    private void Update()
    {
        if (upgrade != null)
        {
            sprite.sprite = upgrade.icon;

        }
        else
        {
            sprite.sprite = null;

        }
    }

    private void OnTriggerEnter2D(Collider2D t_collider)
    {
        if (t_collider.gameObject.CompareTag("player"))
        {
            if (upgrade != null)
            {
                upgrade.Create(t_collider.gameObject);
                generator.RemoveFromPool(upgrade);

                source.PlayOneShot(clip);

                waveController.UpgradeCheck();

                waveController.StartWave();
            }
        }
    }
}
