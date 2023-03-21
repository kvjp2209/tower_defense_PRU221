using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

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

        if (currentCoins >= 101)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn1000coins);
        }
        if (currentCoins >= 150)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn1500coins);
        }
        if (currentCoins >= 2000)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn2000coins);
        }
        if (currentCoins >= 2500)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn2500coins);
        }
    }

    private void Start()
    {
        coinText.text = ": " + currentCoins.ToString();
    }
}
