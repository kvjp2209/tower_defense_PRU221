using UnityEngine;


public class BowProjectile : Projectile
    {
    private Timer timer;
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 0;
        timer.Run();
    }
    void Update()
    {
        Destroy(gameObject, 3);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy newP = collision.gameObject.GetComponent<Enemy>();
            newP.takeDamage(attackDamage);
            Destroy(gameObject);
        }
    }
}

