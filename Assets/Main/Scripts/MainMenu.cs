using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainMenu : MonoBehaviour
{
    private SceneContext _sceneContext;
    private Settings _settings;
    private SaveLoad _saveLoad;

    [Inject]
    private void Construct(SceneContext sceneContext, Settings settings, SaveLoad saveLoad)
    {
        _sceneContext = sceneContext;
        _settings = settings;
        _saveLoad = saveLoad;
    }
    public void NewGame()
    {
        _sceneContext.NewGame();
    }

    public void OpenSettingsPanel()
    {
        _settings.ShowSettingView();
    }

    public void OpenSaveLoadPanel()
    {

        _saveLoad.OpenSaveLoad();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
