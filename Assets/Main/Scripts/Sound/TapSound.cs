using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class TapSound : MonoBehaviour, IPointerDownHandler
{
    public AudioClip tapSound;

    private float _volume = 1;
    
    [Inject]
    public void Construct(Settings settings)
    {
        settings.applySettings += GetNewSttings;
        _volume = settings.settingsPreff.effectsSoundValue;
    }

    private void GetNewSttings(SettingsPreff setings)
    {
        _volume = setings.effectsSoundValue;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioSource.PlayClipAtPoint(tapSound, Vector3.zero, _volume);
    }
}
