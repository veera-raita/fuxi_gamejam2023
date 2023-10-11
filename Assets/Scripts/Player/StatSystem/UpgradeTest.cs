using UnityEngine;

public class UpgradeTest : MonoBehaviour
{
    public UpgradeBase upgrade;
    public SpriteRenderer sprite;
    public GameObject WaveMeme;

    public AudioClip clip;
    public AudioSource source;
    private WaveController waveController;

    private void Start()
    {
        sprite.sprite = upgrade.icon;
        waveController = FindObjectOfType<WaveController>();
    }

    private void OnTriggerEnter2D(Collider2D t_collider)
    {
        if (t_collider.GetComponent<CharacterStatHolder>())
        {
            upgrade.Create(t_collider.gameObject);

            UpgradeGenerator t_generator = FindObjectOfType<UpgradeGenerator>();
            t_generator.RemoveFromPool(upgrade);

            var sus = FindObjectOfType<UpgradeSpawner>();

            source.PlayOneShot(clip);
            Debug.Log("yay yay");

            foreach(var mogus in sus.spawnPoints)
            {
                Destroy(mogus.transform.GetChild(0).gameObject);
                Debug.Log(mogus);
            }

            Debug.Log("meowdy");
            waveController.StartWave();
        }
    }
}
