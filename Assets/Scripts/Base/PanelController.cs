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
    public Button BowTowerButton;
    [SerializeField]
    public Button FireTowerButton;
    [SerializeField]
    public Button MageTowerButton;
    [SerializeField]
    public Button SlimeTowerButton;
    [SerializeField]
    public Button BombTowerButton;
    [SerializeField]
    public Button ExitButton;

    //coin
    [SerializeField]
    public TextMeshProUGUI BowTowerCoin;
    [SerializeField]
    public TextMeshProUGUI FireTowerCoin;
    [SerializeField]
    public TextMeshProUGUI MageTowerCoin;
    [SerializeField]
    public TextMeshProUGUI SlimeTowerCoin;
    [SerializeField]
    public TextMeshProUGUI BombTowerCoin;

    //Tower
    [SerializeField]
    public Tower BowTower;
    [SerializeField]
    public Tower FireTower;
    [SerializeField]
    public Tower MageTower;
    [SerializeField]
    public Tower SlimeTower;
    [SerializeField]
    public Tower BombTower;
    public GameObject Base { get; set; }

    private int currentCoins;

    // Start is called before the first frame update
    void Start()
    {
        BowTowerCoin.text = BowTower.towerCost.ToString();
        FireTowerCoin.text = FireTower.towerCost.ToString();
        MageTowerCoin.text = MageTower.towerCost.ToString();
        SlimeTowerCoin.text = SlimeTower.towerCost.ToString();
        BombTowerCoin.text = BombTower.towerCost.ToString();

        currentCoins = CoinManager.instance.GetCurrentCoins();

        ExitButton.onClick.AddListener(ExitClick);

        BowTowerButton.onClick.AddListener(BowTowerClick);
        FireTowerButton.onClick.AddListener(FireTowerClick);
        MageTowerButton.onClick.AddListener(MageTowerClick);
        SlimeTowerButton.onClick.AddListener(SlimeTowerClick);
        BombTowerButton.onClick.AddListener(BombTowerClick);
    }


    // Update is called once per frame
    void Update()
    {
        currentCoins = CoinManager.instance.GetCurrentCoins();

        if (currentCoins >= BowTower.towerCost)
        {
            BowTowerButton.interactable = true; 
            BowTowerButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            BowTowerButton.interactable = false;
            BowTowerButton.GetComponent<Image>().color = Color.gray;
        }

        if (currentCoins >= FireTower.towerCost)
        {
            FireTowerButton.interactable = true;
            FireTowerButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            FireTowerButton.interactable = false;
            FireTowerButton.GetComponent<Image>().color = Color.gray;
        }

        if (currentCoins >= MageTower.towerCost)
        {
            MageTowerButton.interactable = true;
            MageTowerButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            MageTowerButton.interactable = false;
            MageTowerButton.GetComponent<Image>().color = Color.gray;
        }

        if (currentCoins >= SlimeTower.towerCost)
        {
            SlimeTowerButton.interactable = true;
            SlimeTowerButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            SlimeTowerButton.interactable = false;
            SlimeTowerButton.GetComponent<Image>().color = Color.gray;
        }

        if (currentCoins >= BombTower.towerCost)
        {
            BombTowerButton.interactable = true;
            BombTowerButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            BombTowerButton.interactable = false;
            BombTowerButton.GetComponent<Image>().color = Color.gray;
        }
    }

    private void BowTowerClick()
    {
        CoinManager.instance.SubtractCoins(BowTower.towerCost);
        GameObject Tower;
        Tower = BowTowerObjectPool.shareInstance.GetPooledObject();
        Tower.SetActive(true);
        Tower.transform.position = Base.transform.position;
        Base.SetActive(false);
        Base = Tower;
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
    }

    private void SlimeTowerClick()
    {
        CoinManager.instance.SubtractCoins(SlimeTower.towerCost);
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
        CoinManager.instance.SubtractCoins(MageTower.towerCost);
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
        CoinManager.instance.SubtractCoins(FireTower.towerCost);
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
        CoinManager.instance.SubtractCoins(BombTower.towerCost);
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
