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
        gameObject.transform.position = WayPoints.wayPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move(WayPoints);
        checkCurrentHealh(WayPoints);
        if (Input.GetKeyDown(KeyCode.W))
        {
            healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
        }
    }
}
