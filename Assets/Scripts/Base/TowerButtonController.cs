using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonController : MonoBehaviour
{
    [SerializeField]
    Button TowerButton;
    [SerializeField]
    GameObject TowerPrefab;

    //L?y object base ?? l?y v? trí ??t tower và destroy base
    public GameObject Base { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        TowerButton.onClick.AddListener(TowerSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TowerSpawn()
    {
        GameObject Tower;
        Tower = Instantiate(TowerPrefab, Base.transform.position, Quaternion.identity);
        Base.SetActive(false);
        Base = Tower;
    }
}
