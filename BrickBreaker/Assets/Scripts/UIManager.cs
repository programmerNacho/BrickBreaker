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
    }

    [SerializeField]
    private GameObject pauseMenu;

    public void SetPauseMenu(bool value)
    {
        pauseMenu.SetActive(value);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
