using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTowerInfoGridController : MonoBehaviour
{
    public GameObject backBtn;
    public GameObject allScrollPage;
    public GameObject panelDescription;
    public List<Tower> towers;
    public List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
        GameObject sampleTemplateObject = transform.GetChild(0).gameObject;
        for(int i = 0; i < towers.Count; i++)
        {
            sampleTemplateObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/TowerImage/" + towers[i].name);
            sampleTemplateObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = towers[i].name.ToString();
            GameObject newGameObject = Instantiate(sampleTemplateObject, transform);
            list.Add(newGameObject);
            int towerNumber = i;
            newGameObject.GetComponent<Button>().onClick.AddListener(() => { FillInfomation(towerNumber); });
        }
        Destroy(sampleTemplateObject);
    }

    void FillInfomation(int towerNumber)
    {
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        Tower tower = towers[towerNumber];
        backBtn.SetActive(false);
        allScrollPage.SetActive(false);
        panelDescription.SetActive(true);
        panelDescription.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/TowerImage/" + tower.name);
        panelDescription.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/ProjectileImage/" + tower.projectile.name);
        panelDescription.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = tower.name;
        panelDescription.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Range: " + tower.attackRadius.ToString();
        panelDescription.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Attack Coldown: " + tower.timeBetweenAttacks.ToString();
        panelDescription.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Attack Damage: " + tower.projectile.attackDamage.ToString();
    }

    public void ClosePanelTowerInfo()
    {
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        panelDescription.SetActive(false);
        backBtn.SetActive(true);
        allScrollPage.SetActive(true);
    }
}
