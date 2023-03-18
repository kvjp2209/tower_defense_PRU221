using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMainUI : MonoBehaviour
{
    public void GameOver()
    {

    }
    public void QuitGameButton()
    {
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        SceneManager.LoadScene("MenuScene");
    }
    public void RePlayGameButton()
    {
        this.gameObject.SetActive(false);
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        SceneManager.LoadScene("Map");
    }
}
