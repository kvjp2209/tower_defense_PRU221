using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Enemy : MonoBehaviour
{
    public float speed;
    public WayPoints WayPoints { get; set; }
    public float currentHealth { get; set; }

    [SerializeField]
    public float MaxHealth;

    public HealthBarBehaviour healthBarBehaviour;

    private int waypointIndex;

    bool isDead = false;

    public void setUp()
    {
        
        currentHealth = MaxHealth;
        healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);

    }
    public void getNormalPath()
    {
        int monsterPath = Random.Range(0, 2);
        if (!isDead)
        {
            if (monsterPath == 0)
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointNomal1").GetComponent<WayPoints>();
            }
            else
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointNomal2").GetComponent<WayPoints>();
            }
        }
    }
    public void getDirectPath()
    {
        int monsterPath = Random.Range(0, 2);
        if (!isDead)
        {
            if (monsterPath == 0)
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointBat1").GetComponent<WayPoints>();
            }
            else
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointBat2").GetComponent<WayPoints>();
            }
        }
    }
    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoints.wayPoints[waypointIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, WayPoints.wayPoints[waypointIndex].position) < 0.1f)
        {

            if (waypointIndex < WayPoints.wayPoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Projectile newP = collider2D.gameObject.GetComponent<Projectile>();
        if (collider2D.tag == "Projectile")
        {
            enemyHit(newP.AttackDamage);
            Debug.Log("This is projectile dame " +newP.AttackDamage+ "The end!");
            Destroy(collider2D.gameObject);
        }else if (collider2D.tag == "SlimeProjectile" && newP.PType == projectileType.slime)
        {
            speed = 0.5f;
            enemyHit(newP.AttackDamage);
            Destroy(collider2D.gameObject);
        }
    }
    public void enemyHit(int hitPoints)
    {
        if (currentHealth - hitPoints > 0)
        {
            currentHealth -= hitPoints;
            healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void die()
    {
        isDead = true;
        /*enemyCollider.enabled = false;
        GameManager.Instance.TotalKilled += 1;
        GameManager.Instance.AudioSource.PlayOneShot(SoundManager.Instance.Death);
        GameManager.Instance.AddMoney(rewardAmount);
        GameManager.Instance.isWaveOver();*/
    }
    public void takeDamage(int damege)
    {
        this.currentHealth -= damege;
    }


}
