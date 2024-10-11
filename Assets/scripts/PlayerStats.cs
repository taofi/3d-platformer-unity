using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool gameOver;
    public GameOverScreen gameOverScreen;
    public GameOverScreen winScreen;
    private float elapsedTime;
    private bool isRunning;

    [SerializeField]
    private Text timerText;
    private string timerStr;


    private Animator animator;

    public HealthBar healthBar;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameOver = false;
        animator.SetBool("IsDying", false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
            Lose();

    }
    public void StartTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    public void Lose()
    {
        gameOver = true;
        animator.SetBool("IsDying", true);
        gameOverScreen.Setup(timerStr);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Finish()
    {
        isRunning = false;
        gameOver = true;
        Cursor.lockState = CursorLockMode.None;
        winScreen.Setup(timerStr);
        animator.SetBool("IsWinning", true);


    }

    public void SetHealth(int health)
    {
        currentHealth = health;
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);
        timerStr = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        timerText.text = timerStr;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus && !gameOver)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
