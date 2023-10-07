using UnityEngine;

public class UpgradeTest : MonoBehaviour
{
    public UpgradeBase upgrade;
    public SpriteRenderer sprite;

    private void Start()
    {
        sprite.sprite = upgrade.icon;
    }

    private void OnTriggerEnter2D(Collider2D t_collider)
    {
        if (t_collider.GetComponent<CharacterStatHolder>())
        {
            upgrade.Create(t_collider.gameObject);

            UpgradeGenerator t_generator = FindObjectOfType<UpgradeGenerator>();
            t_generator.RemoveFromPool(upgrade);

            var sus = FindObjectOfType<UpgradeSpawner>();

            foreach(var mogus in sus.spawnPoints)
            {
                Destroy(mogus.transform.GetChild(0).gameObject);
            }
        }
    }
}
