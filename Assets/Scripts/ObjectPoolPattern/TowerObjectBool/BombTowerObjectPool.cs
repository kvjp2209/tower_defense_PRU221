using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTowerObjectPool : ObjectPool
{
    public static BombTowerObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}
