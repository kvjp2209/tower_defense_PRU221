using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int currentCoins = 150;
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

    public void SubtractCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            coinText.text = ": " + currentCoins.ToString();
        }
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        coinText.text = ": " + currentCoins.ToString();

        if (currentCoins >= 200)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn200coins);
        }
        if (currentCoins >= 250)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn250coins);
        }
        if (currentCoins >= 350)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn350coins);
        }
        if (currentCoins >= 500)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn500coins);
        }
    }

    private void Start()
    {
        coinText.text = ": " + currentCoins.ToString();
    }
}
