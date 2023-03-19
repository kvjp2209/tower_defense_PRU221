using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeTowerObjectPool : ObjectPool
{
    public static SlimeTowerObjectPool shareInstance;

    private void Awake()
    {
        shareInstance = this;
    }
}
