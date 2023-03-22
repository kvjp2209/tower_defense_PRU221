using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NormalEnemy : Enemy
{
    // Start is called before the first frame update
    private void Start()
    {
       setUp();
       getNormalPath();
       description = "Spiders will move at a slow speed with base health.";
        gameObject.transform.position = WayPoints.wayPoints[0].position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(WayPoints);
        if (Input.GetKeyDown(KeyCode.W))
        {
            takeDamage(2);
            healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
        }
        try 
        { 
            FindObjectOfType<SlimeProjectile>().isShotBySlimeBullet += isAttackBySlime; } 
        catch { }
        
    }

     public void isAttackBySlime(Enemy enemy)
    {
        enemy.speed = 0.5f;
    }
}
