using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalObjectPool : ObjectPool
{
    public static NormalObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}
