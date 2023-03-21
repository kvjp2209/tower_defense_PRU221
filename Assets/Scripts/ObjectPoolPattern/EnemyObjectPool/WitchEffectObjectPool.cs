using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchEffectObjectPool : ObjectPool {
    public static WitchEffectObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}
