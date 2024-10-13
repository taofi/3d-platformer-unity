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
    public WinScreen winScreen;

    private Timer timer;

    [SerializeField]
    private AudioClip[] damageSoundClips;
    [SerializeField]
    private AudioClip[] winSoundClips;
    [SerializeField]
    private AudioClip[] loseSoundClips;
    private Animator animator;

    public HealthBar healthBar;

    void Start()
    {
        timer = GetComponent<Timer>();
        animator = GetComponent<Animator>();
        gameOver = false;
        animator.SetBool("IsDying", false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        if (transform.position.y <= -20)
            Lose();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        SFXManager.instance.PlayRandomSoundFXClip(damageSoundClips, transform, 1f);

        if (currentHealth <= 0)
            Lose();

    }

    public void Lose()
    {
        if (gameOver)
            return;
        Cursor.lockState = CursorLockMode.None;
        SFXManager.instance.PlayRandomSoundFXClip(loseSoundClips, transform, 1f);

        gameOverScreen.Setup();
        timer.StopTimer();
        animator.SetBool("IsDying", true);
        gameOver = true;

    }

    public void Finish()
    {
        if (gameOver)
            return;
        Cursor.lockState = CursorLockMode.None;
        SFXManager.instance.PlayRandomSoundFXClip(winSoundClips, transform, 1f);
        timer.StopTimer();
        animator.SetBool("IsWinning", true);
        winScreen.Setup(timer.timerStr);
        gameOver = true;

    }

    public void SetHealth(int health)
    {
        currentHealth = health;
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
