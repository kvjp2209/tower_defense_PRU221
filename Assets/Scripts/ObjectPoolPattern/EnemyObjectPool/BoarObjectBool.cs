using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarObjectBool : ObjectPool
{
    public static BoarObjectBool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}
