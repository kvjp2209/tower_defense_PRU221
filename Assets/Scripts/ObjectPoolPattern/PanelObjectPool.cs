using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class PanelObjectPool:ObjectPool
    {
    public static PanelObjectPool shareInstance;
    private void Awake()
    {
        shareInstance = this;
    }
}