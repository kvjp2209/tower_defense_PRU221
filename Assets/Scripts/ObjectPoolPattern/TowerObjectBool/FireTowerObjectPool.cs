using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowerObjectPool : ObjectPool
{
    public static FireTowerObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}
