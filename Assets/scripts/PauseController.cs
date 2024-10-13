using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    public UnityEvent GamePaused;

    public UnityEvent GameResumed;

    private bool _isPaused;

    public GameObject PausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            _isPaused = !_isPaused;

            if (_isPaused)
                Pause();
            else
                Continue();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;
        GamePaused.Invoke();
    }

    public void Continue()
    {   
        _isPaused = false;
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1;
        GameResumed.Invoke();
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