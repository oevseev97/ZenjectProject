using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Zenject;

[RequireComponent(typeof(IViewAction<SettingsPreff>))]
public class Settings : MonoBehaviour
{

    public Action<SettingsPreff> applySettings;

    public SettingsPreff settingsPreff;

    private IViewAction<SettingsPreff> _settingView;

    [Inject]
    private void Construct()
    {
         settingsPreff = LoadSetting();
         _settingView = GetComponent<IViewAction<SettingsPreff>>();
         _settingView.ViewChanged += ApllySettings;  
    }

    public void ShowSettingView()
    {      
        _settingView.Show();
        _settingView.SetData(LoadSetting());
    }

    public void HideAndSave()
    {
        settingsPreff = _settingView.GetData();
        SaveSetting(settingsPreff);       
        HideSettingView();
    }

    public void HideSettingView()
    {
        applySettings.Invoke(settingsPreff);
        _settingView.Hide();
    }

    private void ApllySettings(SettingsPreff data)
    {
        applySettings.Invoke(data);
    }

    private void SaveSetting(SettingsPreff data)
    {
        data.Save();
    }

    private SettingsPreff LoadSetting()
    {
        SettingsPreff preff = new SettingsPreff();
        preff.Load();
        return preff;
    }
}

public class SettingsPreff
{
    public float musicValue = 1;
    public float effectsSoundValue = 1;

    public void Load()
    {
        musicValue = PlayerPrefs.GetFloat("MusicVolume", 1);
        effectsSoundValue = PlayerPrefs.GetFloat("effectsSoundValue", 1);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicValue);
        PlayerPrefs.SetFloat("effectsSoundValue", effectsSoundValue);
    }
}
