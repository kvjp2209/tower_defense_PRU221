using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseController : MonoBehaviour
{
    [SerializeField]
     GameObject panel;
    [SerializeField]
    Button btnBase;
    GameObject panelObject;
    // Start is called before the first frame update
    void Start()
    {
        
        Button yourButton = btnBase.GetComponent<Button>();
        yourButton.onClick.AddListener(ShowPanelClick);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void ShowPanelClick()
    {
        panelObject = PanelObjectPool.shareInstance.GetPooledObject();
        panelObject.SetActive(true);
        Debug.Log(gameObject.transform.localPosition);
       // Destroy(gameObject);
        panelObject.GetComponent<PanelController>().Base = this.gameObject;
        
    }

}
