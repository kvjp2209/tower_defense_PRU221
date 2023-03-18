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
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            takeDamage(1);
            healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        Move();
    }
}
