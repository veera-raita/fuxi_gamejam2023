using UnityEngine;

public class UpgradeTest : MonoBehaviour
{
    public UpgradeBase upgrade;    
    public GameObject WaveMeme;

    public SpriteRenderer sprite;
    public SpriteRenderer glimmer;

    private UpgradeGenerator generator;

    public AudioClip clip;
    public AudioSource source;
    private WaveController waveController;
    

    private void Start()
    {
        waveController = FindObjectOfType<WaveController>();
        generator = FindObjectOfType<UpgradeGenerator>();
    }

    private void Update()
    {
        if (upgrade != null)
        {
            sprite.sprite = upgrade.icon;
            glimmer.color = upgrade.glimmerColor;
            glimmer.gameObject.SetActive(true);
        }
        else
        {
            sprite.sprite = null;
            glimmer.gameObject.SetActive(false);
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
