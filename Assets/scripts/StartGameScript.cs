using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartGameScript : MonoBehaviour
{
    public GameObject ControlPanel;

    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void CloseControlsButton()
    {
        ControlPanel.SetActive(false);
    }
    public void OpenControlsButton()
    {
        ControlPanel.SetActive(true);
    }
    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
