using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingQuitGameUI : MonoBehaviour
{
    public GameObject settingPanel;
    public Slider musicSlider, sfxSlider;
    private void Start()
    {
        musicSlider.value = AudioManager.AudioInstance.musicSource.volume;
        sfxSlider.value = AudioManager.AudioInstance.sfxSource.volume;
        AudioManager.AudioInstance.PlayMusic("BattleTheme");
    }
    public void QuitGameButton()
    {
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        SceneManager.LoadScene("MenuScene");
    }
    public void SettingButton()
    {
        Time.timeScale = 0;
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        settingPanel.SetActive(!settingPanel.activeSelf);
    }
    public void BackButton()
    {
        Time.timeScale = 1;
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        settingPanel.SetActive(!settingPanel.activeSelf);
    }
    public void ToggleMusicButton(Button button)
    {
        ColorBlock colorBlock = button.colors;
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        if (AudioManager.AudioInstance.ToggleMusic() == false)
        {
            colorBlock.normalColor = new Color(245, 255, 0, 255);
            colorBlock.selectedColor = new Color(245, 255, 0, 255);
            colorBlock.disabledColor = new Color(245, 255, 0, 255);
        }
        else
        {
            colorBlock.normalColor = Color.gray;
            colorBlock.selectedColor = Color.gray;
            colorBlock.disabledColor = Color.gray;
        }
        button.colors = colorBlock;
    }
    public void ToggleSFXButton(Button button)
    {
        ColorBlock colorBlock = button.colors;
        AudioManager.AudioInstance.PlaySFX("ButtonClick");
        if (AudioManager.AudioInstance.ToggleSFX() == false)
        {
            colorBlock.normalColor = new Color(245, 255, 0, 255);
            colorBlock.selectedColor = new Color(245, 255, 0, 255);
            colorBlock.disabledColor = new Color(245, 255, 0, 255);
        }
        else
        {
            colorBlock.normalColor = Color.gray;
            colorBlock.selectedColor = Color.gray;
            colorBlock.disabledColor = Color.gray;
        }
        button.colors = colorBlock;
    }
    public void MusicVolume()
    {
        AudioManager.AudioInstance.MusicVolume(musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.AudioInstance.SFXVolume(sfxSlider.value);
    }
}
