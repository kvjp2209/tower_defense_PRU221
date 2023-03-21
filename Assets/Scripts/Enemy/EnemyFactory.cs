using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject CreateEnemy(string type)
    {
        GameObject enemy;
        switch (type)
        {
            case "bat":
                enemy = BatObjectPool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                return enemy;
                
            case "boar":
                enemy = BoarObjectBool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                return enemy;
            case "goblin":
                enemy = GoblinObjectPool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                return enemy;
            case "witch":
                enemy = WitchObjectPool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                return enemy;
            case "normal":
                enemy = NormalObjectPool.shareInstance.GetPooledObject();
                enemy.SetActive(true);
                return enemy;
        }
        return null;
    }
}
