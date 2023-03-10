using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Timer timer;

    private Radar radar;

    private bool shot = true;

    private GameObject target;

    [SerializeField]
    public GameObject bulletPrefab;

    int gunRange = 4;

    int timePerShoot = 1;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        radar = gameObject.AddComponent<Radar>();
        radar.range = gunRange;
        target = new GameObject();
        //target.transform.position = new Vector3(0, -10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if(target != null)
        //{
        //    float angle = Mathf.Atan2(target.transform.position.y - gameObject.transform.position.y, target.transform.position.x - gameObject.transform.position.x) * Mathf.Rad2Deg;
        //    Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1000 * Time.deltaTime);
        //}
    }

    public void Shoot(GameObject closest)
    {
        target = closest;
        if (!shot && timer.Finished)
        {
            shot = true;
        }
        if (shot)
        {
            target = closest;
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = gameObject.transform.position;
            bullet.GetComponent<Bullet>().Destination = target.transform.position;
            shot = false; //bắn xong thì set lại về false 
            timer.Duration = timePerShoot; //thời gian delay bắn đạn
            timer.Run();
        }
    }
}
