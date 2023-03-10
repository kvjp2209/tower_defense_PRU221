using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainController : MonoBehaviour
{
    [SerializeField]
    public GameObject moverPrefab;

    [SerializeField]
    public GameObject gunPrefab;

    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gun = Instantiate(gunPrefab);
        gun.transform.position = new Vector3(-3, (float)-0.7, 0);
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            GameObject mover = ObjectPool.shareInstance.GetPooledObject();
            if (mover != null)
            {
                mover.transform.position = new Vector3(-11, 2, 0);
                mover.SetActive(true);
            }
            timer.Duration = 1;
            timer.Run();
        }        
    }

}
