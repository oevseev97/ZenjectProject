using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContext : MonoBehaviour
{
    public static SceneContext inctance = null;

    private const string GAME_SCENE_NAME = "Game";
    private const string MAIN_MENU_SCENE_NAME = "MainMenu";
    public void Init()
    {

    }

    public void LoadGame()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(GAME_SCENE_NAME);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_NAME);
    }
}
