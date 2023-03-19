using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchObjectPool : ObjectPool
{
    public static WitchObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}
