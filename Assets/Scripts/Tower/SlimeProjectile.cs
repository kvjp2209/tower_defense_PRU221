using UnityEngine;


public class SlimeProjectile : Projectile
    {
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Enemy newP = collider2D.gameObject.GetComponent<Enemy>();
        if (collider2D.tag == "Enemy")
        {
            newP.speed = 0.5f;
            newP.takeDamage(attackDamage);
        }
    }
}

