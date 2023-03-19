using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinObjectPool : ObjectPool
{
    public static GoblinObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}
