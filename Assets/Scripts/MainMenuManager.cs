using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public Button Start, Continue, Options, Exit, AboutUs;

    private void Awake()
    {
        Start.onClick.AddListener(StartNewGame);
        Continue.onClick.AddListener(ContinueGame);
        Options.onClick.AddListener(OpenOption);
        Exit.onClick.AddListener(ExitGame);
        AboutUs.onClick.AddListener(OpenAbout);


    }

    void StartNewGame()
    {
        ProcessController.Instance?.GoNextScene("0-1");
    }

    void ContinueGame()
    {

    }

    void OpenOption()
    {
        OptionController.Instance.StartMenu();
    }

    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void OpenAbout()
    {

    }

}
