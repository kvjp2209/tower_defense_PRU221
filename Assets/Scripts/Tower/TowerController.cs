using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tower : MonoBehaviour
{
    public float timeBetweenAttacks;
    public float attackRadius;
    public Projectile projectile;
    public GameObject targetEnemy = null;
    public float attackCounter;
    public bool isAttacking = false;
    public int upgradeCost;
    public int towerCost;

    public Button buttonUpgrade;
    public TextMeshProUGUI textLever;
    public TextMeshProUGUI textUpgradeCost;
    private int currentLever = 1;
    //private int currentCoins;

    // Start is called before the first frame update
    void Start()
    {
        textUpgradeCost.text = upgradeCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        isAttacking = false;
        Projectile newProjectile = Instantiate(projectile) as Projectile;
        newProjectile.transform.localPosition = transform.localPosition;
        if (targetEnemy == null)
        {
            Destroy(newProjectile);
        }
        else
        {
            StartCoroutine(MoveProjectile(newProjectile));
        }
    }

    IEnumerator MoveProjectile(Projectile projectile)
    {
        while (GetTargetDistance(targetEnemy) > 0.20f && projectile != null && targetEnemy != null)
        {
            var dir = targetEnemy.transform.localPosition - transform.localPosition;
            var angleDirection = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.AngleAxis(angleDirection, Vector3.forward);
            projectile.transform.localPosition = Vector2.MoveTowards(projectile.transform.localPosition, targetEnemy.transform.localPosition, 5f * Time.deltaTime);
            yield return null;
        }
        if (projectile != null || targetEnemy == null)
        {
            Destroy(projectile);
        }
    }

    public float GetTargetDistance(GameObject thisEnemy)
    {
        if (thisEnemy == null)
        {
            thisEnemy = GetNearestEnemy();
            if (thisEnemy == null)
            {
                return 0f;
            }
        }
        return Mathf.Abs(Vector2.Distance(transform.localPosition, thisEnemy.transform.localPosition));
    }

    public GameObject GetNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = enemies[0];
        if (enemies.Length > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                if (Vector2.Distance(enemy.transform.localPosition, transform.position) < Vector2.Distance(closestEnemy.transform.localPosition, transform.position))
                {
                    closestEnemy = enemy;
                }
            }
        }
        return closestEnemy;
    }
    public void UpgradeTower()
    {
        Debug.Log("Upgrade clicked");
        if (CoinManager.instance.GetCurrentCoins() >= upgradeCost)
        {
            Debug.Log("is upgrading with coin = " + CoinManager.instance.GetCurrentCoins() + " and cost " + upgradeCost);
            CoinManager.instance.SubtractCoins(upgradeCost);
            currentLever++;
            textLever.text = "Lever " + currentLever;
            attackRadius *= 1.2f; // Increase the tower's range by 50%
            upgradeCost *= 2; // Double the cost of the tower's next upgrade
            textUpgradeCost.text = upgradeCost.ToString();
        }
    }
}
