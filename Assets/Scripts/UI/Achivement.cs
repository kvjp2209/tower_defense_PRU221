using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Achivement : MonoBehaviour
{
    private Image img;
    public enum AchivementTypes { Earn200coins, Earn250coins, Earn350coins, Earn500coins, Suvive5waves, Suvive10waves, Suvive12waves, Suvive15waves }
    [SerializeField]
    public AchivementTypes achivementTypes;

    public string trophyName;
    public string trophyDescription;

    [SerializeField]
    private TextMeshProUGUI trophyNameText;
    [SerializeField]
    private TextMeshProUGUI trophyDescriptionText;
    public bool isUnlocked { get; private set; }
    public void Awake()
    {
        img = GetComponent<Image>();
        CheckIfAchivementIsUnlocked();
    }
    public void CheckIfAchivementIsUnlocked()
    {
        if (PlayerPrefs.GetInt(achivementTypes.ToString()) == 0)
        {
            img.color = Color.black;
        }
        else
        {
            img.color = Color.white;
            isUnlocked = true;
        }
    }

    public void UnlockThisAchivement()
    {
        PlayerPrefs.SetInt(achivementTypes.ToString(), 1);
        Awake();
    }
    public void OnTouchTrophy()
    {
        trophyNameText.text = trophyName;
        trophyDescriptionText.text = trophyDescription;
    }
}