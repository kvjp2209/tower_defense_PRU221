using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        setUp();
        getNormalPath();
        description = "Goblins possessing high health and speed are also greater than normal monsters.";
        gameObject.transform.position = WayPoints.wayPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move(WayPoints);
        checkHealth(WayPoints);
        if (Input.GetKeyDown(KeyCode.W))
        {
            healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
        }
    }
}
