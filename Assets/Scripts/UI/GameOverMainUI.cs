using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMainUI : MonoBehaviour
{
    private void Start()
    {
        GameOver();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        AudioManager.AudioInstance.musicSource.Stop();
        AudioManager.AudioInstance.PlaySFX("MusicBattleDefeat");
    }
    public void QuitGameButton()
    {
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        SceneManager.LoadScene("MenuScene");
    }
    public void RePlayGameButton()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        SceneManager.LoadScene("MenuScene");
        SceneManager.LoadScene("Map");
    }
}
