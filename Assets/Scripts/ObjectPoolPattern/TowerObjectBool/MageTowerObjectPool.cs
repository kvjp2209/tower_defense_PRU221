using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTowerObjectPool : ObjectPool
{
    public static MageTowerObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }

}
