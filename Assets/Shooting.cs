using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPoint;

    public float fireRate = 0.2f;
    public float bulletSpreadAngle = 0f;
    public int bulletsPerShot = 1;

    public ProjectileBase m_projectilePrefab;

    private float cooldown = 0;

    private void Start()
    {
        cooldown = 0;
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
        for (int i = 0; i < bulletsPerShot; i++)
        {
            float t_angle = Random.Range(-bulletSpreadAngle, bulletSpreadAngle);
            Vector3 t_bulletSpreadAngle = new(0, 0, t_angle / 2);
            Quaternion t_direction = Quaternion.Euler(shootPoint.rotation.eulerAngles + t_bulletSpreadAngle);

            ProjectileBase t_projectile = Instantiate(m_projectilePrefab, shootPoint.position, t_direction);
            t_projectile.Initialize(5, 10);
        }
    }
}
