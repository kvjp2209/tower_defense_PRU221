using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    public int startAmount;
    public int currentAmount;

    // Start is called before the first frame update
    void Start()
    {
        currentAmount = startAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Increase(int amount)
    {
        currentAmount += amount;
    }
    public void Decrease(int amount)
    {
        currentAmount -= amount;
    }

}
