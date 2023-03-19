using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    Button BowTowerButton;
    [SerializeField]
    Button FireTowerButton;
    [SerializeField]
    Button MageTowerButton;
    [SerializeField]
    Button SlimeTowerButton;
    [SerializeField]
    Button BombTowerButton;
    [SerializeField]
    Button ExitButton;


    //coin
    [SerializeField]
    TextMeshPro BowCoin;
    [SerializeField]
    TextMeshPro FireCoin;
    [SerializeField]
    GameObject coinText;

    public GameObject Base { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        BowTowerButton.onClick.AddListener(BowTowerClick);
        FireTowerButton.onClick.AddListener(FireTowerClick);
        MageTowerButton.onClick.AddListener(MageTowerClick);
        SlimeTowerButton.onClick.AddListener(SlimeTowerClick);
        BombTowerButton.onClick.AddListener(BombTowerClick);
        ExitButton.onClick.AddListener(ExitClick);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void BowTowerClick()
    {
        GameObject Tower;
        Tower = BowTowerObjectPool.shareInstance.GetPooledObject();
        Tower.SetActive(true);
        Tower.transform.position = Base.transform.position;
        Base.SetActive(false);
        Base = Tower;
        int coin = int.Parse(BowCoin.text);
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
    }

    private void SlimeTowerClick()
    {
        GameObject Tower;
        Tower = SlimeTowerObjectPool.shareInstance.GetPooledObject();
        Tower.SetActive(true);
        Tower.transform.position = Base.transform.position;
        Base.SetActive(false);
        Base = Tower;
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
    }

    private void MageTowerClick()
    {
        GameObject Tower;
        Tower = MageTowerObjectPool.shareInstance.GetPooledObject();
        Tower.SetActive(true);
        Tower.transform.position = Base.transform.position;
        Base.SetActive(false);
        Base = Tower;
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
    }

    private void FireTowerClick()
    {
        GameObject Tower;
        Tower = FireTowerObjectPool.shareInstance.GetPooledObject();
        Tower.SetActive(true);
        Tower.transform.position = Base.transform.position;
        Base.SetActive(false);
        Base = Tower;
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
    }

    private void BombTowerClick()
    {
        GameObject Tower;
        Tower = BombTowerObjectPool.shareInstance.GetPooledObject();
        Tower.SetActive(true);
        Tower.transform.position = Base.transform.position;
        Base.SetActive(false);
        Base = Tower;
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
    }
    private void ExitClick()
    {
        Base = null;
        this.gameObject.SetActive(false);
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
    }
}
