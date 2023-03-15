using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectPool Pool { get; set; }

    private void Awake()
    {
        Pool = GetComponent<ObjectPool>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        int monsterIndex = Random.Range(0, 5);

        string type = string.Empty;

        switch (monsterIndex)
        {
            case 0:
                type = "Bat";
                break;
            case 1:
                type = "BigBoar";
                break;
            case 2:
                type = "GoblinAxe";
                break;
            case 3:
                type = "SkeletonMage";
                break;
            case 4:
                type = "Spider";
                break;
        }

        Monster monster = Pool.GetObject(type).GetComponent<Monster>();
        monster.Spawn();

        yield return new WaitForSeconds(2.5f);
    }
}
