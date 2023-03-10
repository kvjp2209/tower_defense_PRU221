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


    //Prefabs
    [SerializeField]
    GameObject BowTowerPrefab;
    [SerializeField]
    GameObject FireTowerPrefab;
    [SerializeField]
    GameObject MageTowerPrefab;
    [SerializeField]
    GameObject SlimeTowerPrefab;
    [SerializeField]
    GameObject BombTowerPrefab;


    //coin
    [SerializeField]
    TextMeshPro BowCoin;
    [SerializeField]
    TextMeshPro FireCoin;
    [SerializeField]
    TextMeshPro Coin;
    [SerializeField]

    //L?y object base ?? l?y v? trí ??t tower và destroy base
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
        Tower = Instantiate(BowTowerPrefab, Base.transform.position, Quaternion.identity);
        Base.SetActive(false);
        Base = Tower;
    }

    private void SlimeTowerClick()
    {
        GameObject Tower;
        Tower = Instantiate(SlimeTowerPrefab, Base.transform.position, Quaternion.identity);
        Base.SetActive(false);
        Base = Tower;
    }

    private void MageTowerClick()
    {
        GameObject Tower;
        Tower = Instantiate(MageTowerPrefab, Base.transform.position, Quaternion.identity);
        Base.SetActive(false);
        Base = Tower;
    }

    private void FireTowerClick()
    {
        GameObject Tower;
        Tower = Instantiate(FireTowerPrefab, Base.transform.position, Quaternion.identity);
        Base.SetActive(false);
        Base = Tower;
    }

    private void BombTowerClick()
    {
        GameObject Tower;
        Tower = Instantiate(BombTowerPrefab, Base.transform.position, Quaternion.identity);
        Base.SetActive(false);
        Base = Tower;
    }
    private void ExitClick()
    {
        this.gameObject.SetActive(false);
    }
}
