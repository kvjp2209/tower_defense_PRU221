using UnityEngine;


public class MageProjectile : Projectile
    {
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Enemy newP = collider2D.gameObject.GetComponent<Enemy>();
        if (collider2D.tag == "Enemy")
        {
            newP.takeDamage(attackDamage);
        }
    }
}

