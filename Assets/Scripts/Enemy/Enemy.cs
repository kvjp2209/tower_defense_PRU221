using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed;
    public WayPoints WayPoints { get; set; }
    public float currentHealth { get; set; }

    public string description;

    [SerializeField]
    public float MaxHealth;

    public HealthBarBehaviour healthBarBehaviour;

    private int waypointIndex;

    public void setUp()
    {
        currentHealth = MaxHealth;
        healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
    }
    public void getNormalPath()
    {
        int monsterPath = Random.Range(0, 2);
            if (monsterPath == 0)
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointNomal1").GetComponent<WayPoints>();
            }
            else
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointNomal2").GetComponent<WayPoints>();
            }
    }
    public void getDirectPath()
    {
        int monsterPath = Random.Range(0, 2);
            if (monsterPath == 0)
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointBat1").GetComponent<WayPoints>();
            }
            else
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointBat2").GetComponent<WayPoints>();
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
                HealthBarManager.instance.TakeDamage(MaxHealth);
                Destroy(gameObject);
            }
        }
    }
    public void takeDamage(int damege)
    {
        this.currentHealth -= damege;
    }
}
