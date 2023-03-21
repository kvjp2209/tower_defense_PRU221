using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchEnemy : Enemy
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int damageSpec;
    private float cooldownTimer = Mathf.Infinity;
    public float curhealth;


    // Start is called before the first frame update
    void Start()
    {
        setUp();
        getNormalPath();
        description = "The witch will move slowly, healing enemies within range every second.";
        gameObject.transform.position = WayPoints.wayPoints[0].position;
        damage = damageSpec;
        curhealth = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        checkCurrentHealh(WayPoints);
        if (Input.GetKeyDown(KeyCode.W))
        {
            healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
        }

        cooldownTimer += Time.deltaTime;

        //Attack only when pler in sight
        /*if (PlayerInSight())
        {
            
        }*/
        if (cooldownTimer >= attackCooldown)
        {
            cooldownTimer = 0;
            Healing();
        }

        Move(WayPoints);
        checkHealth(WayPoints);
        curhealth = currentHealth;
    }

    private void Healing()
    {
        // Detect ememies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);

        // Healing them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().healing(damage);
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0,
            Vector2.left, 0, enemyLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(boxCollider.bounds.center, range);
    }

    /*private void DamagePlayer()
    {
        //if player still in range damage
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }*/
}
