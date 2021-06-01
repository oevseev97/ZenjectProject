using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PauseMenuView : MonoBehaviour, IView
{
    private Settings _settings;
    private SceneContext _sceneContext;

    [Inject]
    private void Construct(Settings settings, SceneContext sceneContext)
    {
        Debug.Log("pause init");
        _settings = settings;
        _sceneContext = sceneContext;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void ShowSettings()
    {
        _settings.ShowSettingView();
    }

    public void ExitToMainMenu()
    {
        _sceneContext.GoToMainMenu();
    }
}
