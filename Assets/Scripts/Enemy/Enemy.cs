using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public abstract class Enemy : MonoBehaviour
{
    Vector3 SpawnPoint = new Vector3(-17, -3, 0);
    public float speed;
    public WayPoints WayPoints { get; set; }

    public string description;

    public float currentHealth;
    public int damage { get; set; }
    [SerializeField]
    public float MaxHealth;

    public HealthBarBehaviour healthBarBehaviour;

    private int waypointIndex;

    public GameObject witchEffect;


    public void setUp()
    {
        currentHealth = MaxHealth;
        healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
    }
    public void getNormalPath()
    {
        int monsterPath = Random.Range(0, 3);
            if (monsterPath == 0)
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointNormal1").GetComponent<WayPoints>();
            }
            else if (monsterPath ==1)
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointNormal2").GetComponent<WayPoints>();
            }
             else
            {
            WayPoints = GameObject.FindGameObjectWithTag("WaypointNormal3").GetComponent<WayPoints>();
            }
    }
    public void getDirectPath()
    {
        int monsterPath = Random.Range(0, 3);
            if (monsterPath == 0)
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointBat1").GetComponent<WayPoints>();
            }
            else if(monsterPath ==1)
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointBat2").GetComponent<WayPoints>();
            } else
        {
            WayPoints = GameObject.FindGameObjectWithTag("WaypointBat3").GetComponent<WayPoints>();
        }
    }
    public void Move(WayPoints waypoints)
    {
        if (transform.position.x > waypoints.wayPoints[waypointIndex].position.x)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 0);
        } else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 0);
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints.wayPoints[waypointIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints.wayPoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex < waypoints.wayPoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                HealthBarManager.instance.TakeDamage(MaxHealth);
                waypointIndex = 0;
                gameObject.transform.position = waypoints.wayPoints[0].position;
                currentHealth = MaxHealth;
                this.gameObject.SetActive(false);
            }
        }
    }

    public void takeDamage(int damege)
    {
        this.currentHealth -= damege;
        healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
        if (this.currentHealth <= 0)
        {
            waypointIndex = 0;
            gameObject.transform.position = WayPoints.wayPoints[0].position;
            currentHealth = MaxHealth;
            this.gameObject.SetActive(false);
            CoinManager.instance.AddCoins((int)MaxHealth);
        }
    }

    public void healing(int _value)
    {
        this.currentHealth = Mathf.Clamp(currentHealth + _value, 0, MaxHealth);
        healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
    }

}
