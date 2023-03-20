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
        description = "Aggressive Boar possess high running speed.";
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
                gameObject.SetActive(false);
                CoinManager.instance.AddCoins((int)MaxHealth);
            }
        }
        Move();
    }
}
