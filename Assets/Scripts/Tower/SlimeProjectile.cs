using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;


public class SlimeProjectile : Projectile
    {
    private Timer timer;
    public float sec = 3;
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
            newP.speed = 0.5f;
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

