using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    Vector3 SpawnPoint = new Vector3(-17, -3, 0);
    public GameObject CreateEnemy(string type)
    {
        GameObject enemy;
        switch (type)
        {
            case "bat":
                enemy = BatObjectPool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                enemy.transform.position = SpawnPoint;
                return enemy;
                
            case "boar":
                enemy = BoarObjectBool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                enemy.transform.position = SpawnPoint;
                return enemy;
            case "goblin":
                enemy = GoblinObjectPool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                enemy.transform.position = SpawnPoint;
                return enemy;
            case "witch":
                enemy = WitchObjectPool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                enemy.transform.position = SpawnPoint;
                return enemy;
            case "normal":
                enemy = NormalObjectPool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                enemy.transform.position = SpawnPoint;
                return enemy;
        }
        return null;
    }
}
