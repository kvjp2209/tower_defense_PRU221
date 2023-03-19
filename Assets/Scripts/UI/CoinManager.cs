using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int currentCoins = 100;
    [SerializeField] 
    private TextMeshProUGUI coinText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetCurrentCoins()
    {
        return currentCoins;
    }

    public bool SubtractCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            coinText.text = ": " + currentCoins.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        coinText.text = ": " + currentCoins.ToString();
    }

    private void Start()
    {
        coinText.text = ": " + currentCoins.ToString();
    }
}
