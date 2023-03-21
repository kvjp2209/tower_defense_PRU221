using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveController : MonoBehaviour
{
    private int wave = 0;
    [SerializeField]
    TextMeshProUGUI waveText;
    #region Timer
    Timer wave_timer;
    // the time inteval for each wave
    private int intervalWave = 5;
    #endregion
    SpawnEnemy spawnEnemy;
    // Start is called before the first frame update
    void Start()
    {
        wave_timer = gameObject.AddComponent<Timer>();
        wave_timer.Duration = intervalWave;
        wave_timer.Run();
        waveText.text = "Wave: " + wave;
    }

    // Update is called once per frame
    void Update()
    {
        if (wave == 5)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Suvive5waves);
        }
        if (wave == 10)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Suvive10waves);
        }
        if (wave == 12)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Suvive12waves);
        }
        if (wave == 15)
        {
            AchivementsManager.instance.UnlockAchivement(Achivement.AchivementTypes.Suvive15waves);
        }

        if (wave_timer.Finished)
        {
            //wave=0, first 5 seconds for players to buy towers
            if (wave == 0)
            {
                wave++;
                waveText.text = "Wave: " + wave;
                intervalWave = 15;
                wave_timer.Duration = intervalWave;
                spawnEnemy = gameObject.AddComponent<SpawnEnemy>();
                spawnEnemy.Count = 0;
                spawnEnemy.Wave = wave;
            }
            else
            {
                wave++;
                spawnEnemy.Count = 0;
                spawnEnemy.Wave = wave;
                waveText.text = "Wave: " + wave;
                intervalWave++;
                wave_timer.Duration = intervalWave;
            }
            wave_timer.Run();
        }
    }

    public IEnumerator spawn(float seconds)
    {
        Debug.Log("Enemy");
        yield return new WaitForSeconds(seconds);
    }
}
