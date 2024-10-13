using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameOverScreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void RestartButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Game");
    }
}
