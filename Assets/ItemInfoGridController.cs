using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoGridController : MonoBehaviour
{
    public List<Enemy> enemies;
    // Start is called before the first frame update
    void Start()
    {
        GameObject sampleTemplateObject = transform.GetChild(0).gameObject;
        GameObject newGameObject;
        for(int i = 0; i < enemies.Count; i++)
        {
            sampleTemplateObject.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/EnemyImage/"+enemies[i].name);
            sampleTemplateObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = enemies[i].name.ToString();
            sampleTemplateObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Speed: " + enemies[i].speed.ToString() + "   Health: " + enemies[i].MaxHealth.ToString();
            sampleTemplateObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "XP Point: " + enemies[i].MaxHealth.ToString();
            newGameObject = Instantiate(sampleTemplateObject, transform);
        }
        Destroy(sampleTemplateObject);
    }
}
