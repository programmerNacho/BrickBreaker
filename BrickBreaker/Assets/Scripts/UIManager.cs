using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject loseMenu;
    [SerializeField]
    private GameObject winMenu;

    public void SetPauseMenu(bool value)
    {
        pauseMenu.SetActive(value);
    }

    public void ExitMenu()
    {
        GameManager.Instance.SetGamePaused(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void GameFinished(bool win)
    {
        if(win)
        {
            winMenu.SetActive(true);
        }
        else
        {
            loseMenu.SetActive(true);
        }
    }
}
