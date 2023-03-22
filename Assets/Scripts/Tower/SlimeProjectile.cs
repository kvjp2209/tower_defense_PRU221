using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class SlimeProjectile : Projectile
    {
    private Timer timer;
    public float sec = 3;
    public delegate void isShotBySlime(Enemy enemy);
    public event isShotBySlime isShotBySlimeBullet;
    void Start()
    {
        
    }
    void Update()
    {
        Destroy(gameObject,3);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy newP = collision.gameObject.GetComponent<Enemy>();
            if (isShotBySlimeBullet != null)
            {
                isShotBySlimeBullet(newP);
            }
            newP.takeDamage(attackDamage);
            Destroy(gameObject);
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }
}

