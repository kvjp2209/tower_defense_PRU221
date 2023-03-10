using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1;
    private WayPoints wayPoints;

    private int waypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        wayPoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<WayPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, wayPoints.waypoints[waypointIndex].position) < 0.1f){
            if(waypointIndex < wayPoints.waypoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                Destroy(gameObject);
            }            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ArrowBullet"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("SlimeBullet"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("LastPoint"))
        {      
                gameObject.SetActive(false);
        }
    }
}
