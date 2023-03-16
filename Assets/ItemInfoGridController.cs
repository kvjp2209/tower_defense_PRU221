using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoGridController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject sampleTemplateObject = transform.GetChild(0).gameObject;
        GameObject newGameObject;
        for(int i = 0; i < 4; i++)
        {
            newGameObject = Instantiate(sampleTemplateObject, transform);
        }
        Destroy(sampleTemplateObject);
    }
}
