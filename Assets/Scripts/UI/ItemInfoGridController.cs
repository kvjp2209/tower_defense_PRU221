using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoGridController : MonoBehaviour
{
    public GameObject backBtn;
    public GameObject allScrollPage;
    public GameObject panelDescription;
    public List<Enemy> enemies;
    public List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
        GameObject sampleTemplateObject = transform.GetChild(0).gameObject;
        for(int i = 0; i < enemies.Count; i++)
        {
            sampleTemplateObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/EnemyImage/"+enemies[i].name);
            sampleTemplateObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = enemies[i].name.ToString();
            GameObject newGameObject = Instantiate(sampleTemplateObject, transform);
            list.Add(newGameObject);
            int enemyNumber = i;
            newGameObject.GetComponent<Button>().onClick.AddListener(() => { FillInfomation(enemyNumber); });
        }
        Destroy(sampleTemplateObject);
    }

    void FillInfomation(int enemyNumber)
    {
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        Enemy enemy = enemies[enemyNumber];
        backBtn.SetActive(false);
        allScrollPage.SetActive(false);
        panelDescription.SetActive(true);
        panelDescription.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/EnemyImage/" + enemy.name);
        panelDescription.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = enemy.name;
        panelDescription.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Speed: " + enemy.speed.ToString();
        panelDescription.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Health: " + enemy.MaxHealth.ToString();
        panelDescription.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "XP Point: " + enemy.MaxHealth.ToString();
        panelDescription.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Description: " + enemy.description;
    }

    public void ClosePanelEnemyInfo()
    {
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        panelDescription.SetActive(false);
        backBtn.SetActive(true);
        allScrollPage.SetActive(true);
    }
}
