using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool shareInstance;
    public Dictionary<string,List<GameObject>> pooledObjects;
    [SerializeField]
    public GameObject objectToPool;
    [SerializeField]
    public int amountToPool;
    [SerializeField]
    private GameObject[] objectPrefabs;

    private void Awake()
    {
        shareInstance = this;
    }

    /*public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }*/

    public GameObject GetObject(string type)
    {
        if (pooledObjects.ContainsKey(type))
        {
            if (pooledObjects[type].Count > 0)
            {
                GameObject gameObject = pooledObjects[type][pooledObjects[type].Count - 1];
                pooledObjects[type].RemoveAt(pooledObjects[type].Count - 1);
                gameObject.SetActive(true);
                return gameObject;
            }
            else
            {
                pooledObjects[type].Capacity++;
                return GetNewObject(type);
            }
        } else
        {
            return null;
        }
    }

    /*public void ReturnObject(string type)
    {
        if (pooledObjects.ContainsKey(type))
        {
            pooledObjects[type].Add()
        }
    }*/
    public GameObject getFirst()
    {
        GameObject gameObject = GetObject(objectPrefabs[0].name);
        return gameObject;
    }
    public void ReleaseObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    GameObject GetNewObject(string type)
    {
        for (int i = 0; i < objectPrefabs.Length; i++)
        {
            if (objectPrefabs[i].name == type)
            {
                GameObject newObject = Instantiate(objectPrefabs[i]);
                gameObject.SetActive(false);
                newObject.name = type;
                return newObject;
            }
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {       
        GameObject tmp;
        pooledObjects = new Dictionary<string, List<GameObject>>();
        for (int i = 0; i < objectPrefabs.Length; i++)
        {
            List<GameObject> listObjectSameType = new List<GameObject>();
            if (!pooledObjects.ContainsKey(objectPrefabs[i].name)){
                for (int j = 0; j < amountToPool; j++)
                {
                    tmp = Instantiate(objectPrefabs[i]);
                    tmp.SetActive(false);
                    tmp.name = objectPrefabs[i].name;
                    listObjectSameType.Add(tmp);
                }
                pooledObjects.Add(objectPrefabs[i].name, listObjectSameType);
            }
        }       
    }
}
