using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    public List<GameObject> pooledObjects;
    [SerializeField]
    public GameObject objectToPool;
    [SerializeField]
    public int amountToPool;


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
}
