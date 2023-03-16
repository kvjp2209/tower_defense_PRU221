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

                var BatPrefabs = Resources.Load("Prefabs/Enemy/Bat") as GameObject;
                Debug.Log("Created");
                if (BatPrefabs != null)
                {
                    enemy = Instantiate(BatPrefabs, SpawnPoint, Quaternion.identity);
                    return enemy;
                }
                else
                {
                    throw new System.ArgumentException("Prefab does not exist.");

                }
                
            case "boar":
                var BoarPrefabs = Resources.Load("Prefabs/Enemy/BigBoar") as GameObject;
                Debug.Log("Created");
                if (BoarPrefabs != null)
                {
                    enemy = Instantiate(BoarPrefabs, SpawnPoint, Quaternion.identity);
                    return enemy;
                }
                else
                {
                    throw new System.ArgumentException("Prefab does not exist.");

                }
            case "goblin":
                var GoblinPrefabs = Resources.Load("Prefabs/Enemy/GoblinAxe") as GameObject;
                Debug.Log("Created");
                if (GoblinPrefabs != null)
                {
                    enemy = Instantiate(GoblinPrefabs, SpawnPoint, Quaternion.identity);
                    return enemy;
                }
                else
                {
                    throw new System.ArgumentException("Prefab does not exist.");

                }
            case "witch":
                var WitchPrefabs = Resources.Load("Prefabs/Enemy/SkeletonMage") as GameObject;
                Debug.Log("Created");
                if (WitchPrefabs != null)
                {
                    enemy = Instantiate(WitchPrefabs, SpawnPoint, Quaternion.identity);
                    return enemy;
                }
                else
                {
                    throw new System.ArgumentException("Prefab does not exist.");

                }
            case "normal":
                var NormalPrefabs = Resources.Load("Prefabs/Enemy/Spider") as GameObject;
                Debug.Log("Created");
                if (NormalPrefabs != null)
                {
                    enemy = Instantiate(NormalPrefabs, SpawnPoint, Quaternion.identity);
                    return enemy;
                }
                else
                {
                    throw new System.ArgumentException("Prefab does not exist.");

                }
        }
        return null;
    }
}
