using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(string timer) 
    {
        gameObject.SetActive(true);
        pointsText.text = timer;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
