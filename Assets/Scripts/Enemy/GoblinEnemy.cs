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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            takeDamage(30);
            healthBarBehaviour.setHealthBar(currentHealth, MaxHealth);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                CoinManager.instance.AddCoins((int)MaxHealth);
            }
        }
        Move();
    }
}
