using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseController : MonoBehaviour
{
    [SerializeField]
    Button btnBase;
    [SerializeField]
    Canvas canvas;
    Camera cam;
    GameObject panelObject;
    // Start is called before the first frame update
    void Start()
    {
      cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
      canvas.GetComponent<Canvas>().worldCamera = cam;
        Button yourButton = btnBase.GetComponent<Button>();
        yourButton.onClick.AddListener(ShowPanelClick);

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPanelClick()
    {
        //  AudioManager.AudioInstance.PlaySFX("ButtonClick");
        panelObject = PanelObjectPool.shareInstance.GetPooledObject();
        Debug.Log("Click base");
       panelObject.SetActive(true);
        panelObject.GetComponent<PanelController>().Base = this.gameObject;
    }
}
