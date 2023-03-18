using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTowerObjectPool : ObjectPool
{
    public static BowTowerObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}
