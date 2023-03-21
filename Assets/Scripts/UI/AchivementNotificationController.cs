using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AchivementNotificationController : MonoBehaviour
{
    public static AchivementNotificationController instance;

    [SerializeField] 
    private TextMeshProUGUI achivevementText;

    private Timer timer;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration= 3;
        timer.Run();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.Finished)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetTextAchivevement(string text)
    {
        achivevementText.text = text;
        AudioManager.AudioInstance.PlaySFX("Achivevement");
    }
}
