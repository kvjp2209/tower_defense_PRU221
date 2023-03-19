using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatObjectPool : ObjectPool
{
    public static BatObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}
