using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarEnemy : Enemy
{
    

    // Start is called before the first frame update
    void Start()
    {
        setUp();
        getNormalPath();
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
