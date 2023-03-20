using UnityEngine;

public class MageTower : Tower
    {
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attackCounter -= Time.deltaTime;
        if (targetEnemy == null)
        {
            GameObject nearestEnemy = GetNearestEnemy();
            if (nearestEnemy != null && Vector2.Distance(transform.localPosition, nearestEnemy.transform.localPosition) <= attackRadius)
            {
                targetEnemy = nearestEnemy;
            }
        }
        else
        {
            if (attackCounter <= 0f)
            {
                isAttacking = true;
                attackCounter = timeBetweenAttacks;
            }
            else
            {
                isAttacking = false;
            }
            if (Vector2.Distance(transform.position, targetEnemy.transform.position) > attackRadius)
            {
                targetEnemy = null;
            }
            else if (!targetEnemy.activeSelf)
            {
                targetEnemy = null;
            }
        }
        if (isAttacking == true) { Attack(); }
    }
    /*public GameObject GetEnemyInRange()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                if (Vector2.Distance(enemy.transform.localPosition, transform.position) <= attackRadius)
                {
                    closestEnemy = enemy;
                }
            }
        }
        return closestEnemy;
    }*/
}

