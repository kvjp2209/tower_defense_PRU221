using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    #region Spawn Property
    // list of all type monsters in the game
    private string[] listTypeEnemy;
    //list of enemy used to generate in a wave
    private string[] listEnemySpawn;
    // number of enemies spawned in this wave
    private int size;
    // number of type enemy spawned in this wave
    private int numberOfTypeEnemy;
    // the time interval between each enemu spawn
    private int intervalEnemy = 1;

    private int random;
    public int Wave { get; set; }
    public int Count { get; set; }

    EnemyFactory enemyFactory;
    #endregion
    #region Timer Spawn Enemy
    Timer spawnEnemy_timer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy_timer = gameObject.AddComponent<Timer>();
        spawnEnemy_timer.Duration = intervalEnemy;
        spawnEnemy_timer.Run();

        //get list type of all enemies
        listTypeEnemy = new string[5] {"normal", "goblin", "witch", "bat","boar" };
        listEnemySpawn = new string[5];

        enemyFactory = gameObject.AddComponent<EnemyFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        updateProperty();
        if (spawnEnemy_timer.Finished)
        {
            if(Count < size)
            {
                random = Random.Range(0, numberOfTypeEnemy);
                Debug.Log(listEnemySpawn[random]);
                enemyFactory.CreateEnemy(listEnemySpawn[random]);
                Count++;
                spawnEnemy_timer.Run();
            }
        }
    }

     void updateProperty()
    {
        size = 4 + Wave;
        if(Wave > 5) { numberOfTypeEnemy = 5; }
        else
        {
            numberOfTypeEnemy = Wave;
        }
        
       
        for (int i = 0; i < numberOfTypeEnemy; i++)
        {
            listEnemySpawn[i] = listTypeEnemy[i];
        }
    }

}
