using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int currentCoins = 190;
    [SerializeField] 
    private TextMeshProUGUI coinText;
    public delegate void isReach200Coin(Achivement.AchivementTypes achivementTypes);
    public event isReach200Coin isReach200TargetCoin;
    public delegate void isReach250Coin(Achivement.AchivementTypes achivementTypes);
    public event isReach250Coin isReach250TargetCoin;
    public delegate void isReach350Coin(Achivement.AchivementTypes achivementTypes);
    public event isReach350Coin isReach350TargetCoin;
    public delegate void isReach500Coin(Achivement.AchivementTypes achivementTypes);
    public event isReach500Coin isReach500TargetCoin;
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
   /* void Update()
    {
        AchivementsManager.instance.isReachAchivement();
    }*/

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        coinText.text = ": " + currentCoins.ToString();

        if (currentCoins >= 200)
        {
            AchivementsManager.instance.isReachAchivement();
            if (isReach200TargetCoin != null)
            {
                isReach200TargetCoin(Achivement.AchivementTypes.Earn200coins);
            }
        }
        if (currentCoins >= 250)
        {
            /*AchivementsManager.instance.isReachAchivement();
            if (isReach250TargetCoin != null)
            {
                isReach250TargetCoin(Achivement.AchivementTypes.Earn250coins);
            }*/
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn250coins);
        }
        if (currentCoins >= 350)
        {
            /*AchivementsManager.instance.isReachAchivement();
            if (isReach350TargetCoin != null)
            {
                isReach350TargetCoin(Achivement.AchivementTypes.Earn350coins);
            }*/
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn350coins);
        }
        if (currentCoins >= 500)
        {
            /*AchivementsManager.instance.isReachAchivement();
            if (isReach500TargetCoin != null)
            {
                isReach500TargetCoin(Achivement.AchivementTypes.Earn500coins);
            }*/
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Earn500coins);
        }
    }

    private void Start()
    {
        coinText.text = ": " + currentCoins.ToString();
    }
}
