using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPoint;

    public float fireRate = 0.2f;
    public float shootAngle = 0f;
    public int projectileAmount = 1;

    public GameObject projectile;

    private float cooldown = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (cooldown + fireRate <= Time.time)
        {
            SpawnProjectile();
            cooldown = Time.time;
        }       
    }

    private void SpawnProjectile()
    {
        for (int i = 0; i < projectileAmount; i++)
        {
            float t_angle = Random.Range(-shootAngle, shootAngle) / 2;
            Vector3 t_rotationVector = new(0, 0, t_angle);
            Quaternion t_direction = Quaternion.Euler(t_rotationVector);

            GameObject t_projectile = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
            t_projectile.GetComponent<Rigidbody2D>().AddForce(shootPoint.up * 10, ForceMode2D.Impulse);
            Destroy(t_projectile, 1f);
        }
    }
}
