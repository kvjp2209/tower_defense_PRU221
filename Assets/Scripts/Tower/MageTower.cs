using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : Tower
{
    public float range = 5f;
    public float fireRate = 1f;

    private float fireCountdown = 0f;
    private List<Transform> targets = new List<Transform>();

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTargets", 0f, 0.5f);
    }

    void UpdateTargets()
    {
        targets.Clear();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                targets.Add(collider.transform);
            }
        }
    }

    void Update()
    {
        if (targets.Count == 0)
            return;

        if (fireCountdown <= 0f)
        {
            Fire();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Fire()
    {
        foreach (Transform target in targets)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            MageProjectile bullet = bulletGO.GetComponent<MageProjectile>();

            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
