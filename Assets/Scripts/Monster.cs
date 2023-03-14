using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    private WayPoints WayPoints;

    private int waypointIndex;
    private void Start()
    {
        int monsterPath = Random.Range(0, 2);
        if (gameObject.tag.Equals("Bat")) {
            if (monsterPath == 0) {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointBat1").GetComponent<WayPoints>();
            } else
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointBat2").GetComponent<WayPoints>();
            }
        } else
        {
            if (monsterPath == 0)
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointNomal1").GetComponent<WayPoints>();
            }
            else
            {
                WayPoints = GameObject.FindGameObjectWithTag("WaypointNomal2").GetComponent<WayPoints>();
            }
        }  
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, WayPoints.wayPoints[waypointIndex].position, speed * Time.deltaTime);

        Vector3 dir = WayPoints.wayPoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Vector2.Distance(transform.position, WayPoints.wayPoints[waypointIndex].position) < 0.1f)
        {

            if (waypointIndex < WayPoints.wayPoints.Length - 1)
            {
                waypointIndex++;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }


    [SerializeField]
    private GameObject startPortal;
    public void Spawn()
    {
        transform.position = startPortal.transform.position;

        StartCoroutine(Scale(new Vector3(0.1f, 0.1f), new Vector3(1, 1)));
    }


    public IEnumerator Scale(Vector3 from, Vector3 to)
    {
        float progress = 0;

        while (progress <= 1)
        {
            transform.localScale = Vector3.Lerp(from, to, progress);
            
            progress += Time.deltaTime;

            yield return null;
        }

        transform.localScale = to;
    }
}
