using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        setUp();
        getDirectPath();
        description = "Bats fly directly into the main Tower without following the path on the map.";
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
