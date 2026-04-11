using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("Resolution")]

    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedRes;
    public TMP_Text resolutionLabel;

    public Toggle fullscreenTog;

    [Header ("Audio")]

    public AudioMixer mainMixer;

    public static float masterVolume;
    public static float musicVolume;
    public static float SFXVolume;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;


    void Start()
    {
        if(PlayerPrefs.GetInt("FirstTimeOpening") == null)
        {
            ResetVolumePrefs();
            UpdateMixerVolume();
            PlayerPrefs.SetInt("FirstTimeOpening", 1);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        masterVolume = PlayerPrefs.GetFloat("MasterSliderValue");
        musicVolume = PlayerPrefs.GetFloat("MusicSliderValue");
        SFXVolume = PlayerPrefs.GetFloat("SFXSliderValue");

        masterSlider.value = PlayerPrefs.GetFloat("MasterSliderValue");
        musicSlider.value = PlayerPrefs.GetFloat("MusicSliderValue");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSliderValue");

        fullscreenTog.isOn = Screen.fullScreen;

        bool foundRes = false;
        for(int i = 0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedRes = i;
                UpdateResLabel();
            }
        }

        if (!foundRes)
        {
            //finds players screen width and automatically assigns width and hight 
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectedRes = resolutions.Count - 1;
            UpdateResLabel();
        }
    }


    public void PlayPressed()
    {
        SceneManager.LoadScene("OrbisPC");

        PlayerPrefs.SetFloat("MasterSliderValue", masterVolume);
        PlayerPrefs.SetFloat("MusicSliderValue", musicVolume);
        PlayerPrefs.SetFloat("SFXSliderValue", SFXVolume);

        PlayerPrefs.Save();
    }

    public void QuitPressed()
    {
        PlayerPrefs.SetFloat("MasterSliderValue", masterVolume);
        PlayerPrefs.SetFloat("MusicSliderValue", musicVolume);
        PlayerPrefs.SetFloat("SFXSliderValue", SFXVolume);

        PlayerPrefs.Save();
        Application.Quit();

        Debug.Log("Quit");
    }

    public void MasterVolumeChange(float value)
    {
        masterVolume = value;
        UpdateMixerVolume();
    }

    public void MusicVolumeChange(float value)
    {
        musicVolume = value;
        UpdateMixerVolume();
    }

    public void SFXVolumeChange(float value)
    {
        SFXVolume = value;
        UpdateMixerVolume();
    }

    public void UpdateMixerVolume()
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20);
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(SFXVolume) * 20);
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);

        PlayerPrefs.SetFloat("MasterSliderValue", masterVolume);
        PlayerPrefs.SetFloat("MusicSliderValue", musicVolume);
        PlayerPrefs.SetFloat("SFXSliderValue", SFXVolume);

        PlayerPrefs.Save();
    }

    void ResetVolumePrefs()
    {
        PlayerPrefs.SetFloat("MasterSliderValue", 50);
        PlayerPrefs.SetFloat("MusicSliderValue", 50);
        PlayerPrefs.SetFloat("SFXSliderValue", 50);

        PlayerPrefs.Save();

        masterVolume = PlayerPrefs.GetFloat("MasterSliderValue");
        musicVolume = PlayerPrefs.GetFloat("MusicSliderValue");
        SFXVolume = PlayerPrefs.GetFloat("SFXSliderValue");
        
    }

    public void ResLeft()
    {
        selectedRes--;

        if (selectedRes < 0)
        {
            selectedRes = 0;
        }

        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedRes++;

        if(selectedRes > resolutions.Count - 1)
        {
            selectedRes = resolutions.Count - 1;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedRes].horizontal.ToString() + " x " + resolutions[selectedRes].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        Debug.Log("ApplyGraphics");
        Screen.SetResolution(resolutions[selectedRes].horizontal, resolutions[selectedRes].vertical, fullscreenTog.isOn);
    }


}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
