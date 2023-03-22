using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AchivementsManager : MonoBehaviour
{
    public static AchivementsManager instance;
    [SerializeField] 
    private AchivementNotificationController achivementNotificationController;

    [SerializeField]
    private Achivement[] trophies;
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        instance = this;
        achivementNotificationController.gameObject.SetActive(true);
        achivementNotificationController.gameObject.SetActive(false);
        DontDestroyOnLoad(gameObject);
        
    }
    public void isReachAchivement()
    {
        Debug.Log("This is first achivement");
        CoinManager.instance.isReach200TargetCoin += UnlockAchivement;
/*        Debug.Log("This is second achivement");
        CoinManager.instance.isReach250TargetCoin += UnlockAchivement;
        Debug.Log("This is third achivement");
        CoinManager.instance.isReach350TargetCoin += UnlockAchivement;
        Debug.Log("This is fourth achivement");
        CoinManager.instance.isReach500TargetCoin += UnlockAchivement;*/
    }
    public void UnlockAchivement(Achivement.AchivementTypes achivementTypes)
    {
        Debug.Log(achivementTypes.ToString());
        Debug.Log(trophies.Length);
        foreach(var t in trophies)
        {
            if(t.achivementTypes == achivementTypes)
            {
                if (!t.isUnlocked)
                {
                    t.UnlockThisAchivement();
                    achivementNotificationController.gameObject.SetActive(true);
                    achivementNotificationController.SetTextAchivevement(t.trophyName);
                }
            }
        }
       //// Achivement achivementToUnlock = trophies.SingleOrDefault(t => t.achivementTypes == achivementTypes);
       // Achivement achivementToUnlock = Array.Find(trophies, t => t.achivementTypes == achivementTypes);
       // if (achivementToUnlock == null)
       // {
       //     Debug.LogWarning("trophy not added with achivement:" + achivementTypes);
       //     return;
       // }
       // if (!achivementToUnlock.isUnlocked)
       // {
       //     achivementToUnlock.UnlockThisAchivement();
       // }
    }
}
