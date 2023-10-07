using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPoint;

    public ProjectileBase m_projectilePrefab;
    private CharacterStatHolder m_characterStatHolder;

    private float cooldown = 0;

    private void Start()
    {
        m_characterStatHolder = GetComponent<CharacterStatHolder>();
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
        if (cooldown + m_characterStatHolder.RateOfFire <= Time.time)
        {
            SpawnProjectile();
            cooldown = Time.time;
        }       
    }

    private void SpawnProjectile()
    {
        for (int i = 0; i < m_characterStatHolder.ProjectileAmount; i++)
        {
            float t_angleValue = m_characterStatHolder.ProjectileSpread;
            float t_angle = Random.Range(-t_angleValue, t_angleValue);
            Vector3 t_bulletSpreadAngle = new(0, 0, t_angle / 2);
            Quaternion t_direction = Quaternion.Euler(shootPoint.rotation.eulerAngles + t_bulletSpreadAngle);

            ProjectileBase t_projectile = Instantiate(m_projectilePrefab, shootPoint.position, t_direction);
            t_projectile.Initialize((int)m_characterStatHolder.ProjectileDamage,
                                    (int)m_characterStatHolder.ProjectileRange,
                                    (int)m_characterStatHolder.ProjectileSpeed);
        }
    }
}
