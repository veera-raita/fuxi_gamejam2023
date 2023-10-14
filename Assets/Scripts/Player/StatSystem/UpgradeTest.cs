using UnityEngine;

public class UpgradeTest : MonoBehaviour
{
    public UpgradeBase upgrade;

    public SpriteRenderer sprite;
    public SpriteRenderer glimmer;

    public AudioClip clip;
    public AudioSource source;
    private WaveController waveController;
    

    private void Start()
    {
        waveController = FindObjectOfType<WaveController>();
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
                FindObjectOfType<UpgradeGenerator>().RemoveFromPool(upgrade);
                FindObjectOfType<UpgradeTooltip>().HideTooltip();

                source.PlayOneShot(clip);

                waveController.UpgradeCheck();

                waveController.StartWave();
            }
        }
    }
}