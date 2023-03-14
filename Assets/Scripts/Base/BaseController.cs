using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseController : MonoBehaviour
{
    [SerializeField]
     GameObject panelObject;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPanelClick()
    {
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
     //   panelObject = PanelObjectPool.shareInstance.GetPooledObject();
        panelObject.SetActive(true);
        panelObject.GetComponent<PanelController>().Base = this.gameObject;
    }
}
