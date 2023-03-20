using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NormalEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
       setUp();
       getNormalPath();
       description = "Spiders will move at a slow speed with base health.";
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
    }
}
