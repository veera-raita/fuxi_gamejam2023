using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer volumeMaster;



    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedVolume", 10));
    }

    public void SetVolume(float vValue)
    {
        if (vValue < 1)
        {
            vValue = 0.0001f;
        }

        RefreshSlider(vValue);
        PlayerPrefs.SetFloat("SavedVolume", vValue);
        volumeMaster.SetFloat("MasterVolume", Mathf.Log10(vValue / 100) * 20f);
    }

    public void SetVolFromSlider()
    {
        SetVolume(volumeSlider.value);
    }

    public void RefreshSlider(float vValue)
    {
        volumeSlider.value = vValue;
    }

}
