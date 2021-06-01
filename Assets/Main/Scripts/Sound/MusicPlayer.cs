using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    [Inject]
    private void Construct(Settings settings)
    {
        _audioSource = GetComponent<AudioSource>();
        settings.applySettings += GetNewSttings;
        _audioSource.volume = settings.settingsPreff.musicValue;     
    }

    private void GetNewSttings(SettingsPreff setings)
    {
        SetVolume(setings.musicValue);
    }
    private void SetVolume(float volume)
    {
        _audioSource.volume = volume;      
    }
}
