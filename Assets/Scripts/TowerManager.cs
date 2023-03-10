using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int cost;
    public float range;
    public float fireRate;
    public float damage;
    public int type; 

    private Transform target;
    private float splashRadius = 0f;
    private bool isFreezing = false;

    public GameObject bulletPrefab;
    public GameObject impactEffect;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (type == 4) // sniper tower
        {
            transform.LookAt(target);
        }
        else
        {
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        if (fireRate <= 0f)
        {
            if (type == 3) // splash tower
            {
                SplashDamage();
            }
            else
            {
                Shoot();
            }
            fireRate = 1f / fireRate;
        }

        fireRate -= Time.deltaTime;

        if (type == 5 && !isFreezing) // freeze tower
        {
            /*StartCoroutine(FreezeTarget());*/
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            /*bullet.damage = damage;
            bullet.Seek(target);*/
        }
    }

    void SplashDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, splashRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                /*Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }*/
            }
        }
    }

    /*IEnumerator FreezeTarget()
    {
        isFreezing = true;
        target.GetComponent<Enemy>().Slow(0.5f); // 50% slow
        yield return new WaitForSeconds(2f); // freeze for 2 seconds
        target.GetComponent<Enemy>().Slow(1f); // reset speed
        isFreezing = false;
    }*/
}
