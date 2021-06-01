using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SettingsView : MonoBehaviour, IViewAction<SettingsPreff>
{
    public Slider musicVolumeSlider;
    public Slider effectsVolumeSlider;

    public event Action<SettingsPreff> ViewChanged;
    public void ChangedView()
    {
        ViewChanged.Invoke(GetData());
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetData(SettingsPreff data)
    {
        musicVolumeSlider.value = data.musicValue;
        effectsVolumeSlider.value = data.effectsSoundValue;
    }

    public SettingsPreff GetData()
    {
        SettingsPreff preff = new SettingsPreff();
        preff.musicValue = musicVolumeSlider.value;
        preff.effectsSoundValue = effectsVolumeSlider.value;
   
        return preff;
    }

 
}
