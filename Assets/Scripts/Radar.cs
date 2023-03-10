using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Radar : MonoBehaviour
{
    UnityEvent m_MyEvent;
    public Collider2D[] close = new Collider2D[0];
    GameObject closest;
    Gun gun;
    public int range;

    // Start is called before the first frame update
    void Start()
    {
        if (m_MyEvent == null) m_MyEvent = new UnityEvent();
        m_MyEvent.AddListener(Ping);
        gun = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        close = Physics2D.OverlapCircleAll(gameObject.transform.position, range, LayerMask.GetMask("Default"));
        if (close.Length > 0)
        {
            closest = findClosestEnemy(close);
            m_MyEvent.Invoke();
        }
    }

    void Ping() => gun.Shoot(closest);

    private GameObject findClosestEnemy(Collider2D[] close)
    {
        GameObject closestEnemy = close[0].gameObject;
        float closestDistance = float.MaxValue;
        bool first = true;
        for(int i=0; i < close.Length; i++)
        {
            float distance = Vector3.Distance(close[i].gameObject.transform.position, gameObject.transform.position);
            if (first)
            {
                closestDistance = distance;
                first = false;
            }
            else if (distance < closestDistance)
            {
                closestEnemy = close[i].gameObject;
                closestDistance = distance;
            }
        }
        return closestEnemy;
    }
}
