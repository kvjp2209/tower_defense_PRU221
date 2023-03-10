using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinController : UI
{
    TextMeshPro txtCoin;


    // Start is called before the first frame update
    void Start()
    {
        txtCoin.text = "Coin: " + startAmount;
    }

    // Update is called once per frame
    void Update()
    {
        txtCoin.text = "Coin: " + currentAmount;
    }
  
}
