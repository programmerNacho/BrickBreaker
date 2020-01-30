using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

    private List<Ball> balls;
    private List<Brick> bricks;

    private bool gamePaused = false;

    private void Start()
    {
        balls = new List<Ball>(FindObjectsOfType<Ball>());
        bricks = new List<Brick>(FindObjectsOfType<Brick>());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SetGamePaused(!gamePaused);
        }
    }

    public void DestroyBall(Ball ball)
    {
        if(balls.Contains(ball))
        {
            balls.Remove(ball);
            Destroy(ball.gameObject);
            if(balls.Count <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void DestroyBrick(Brick brick)
    {
        if(bricks.Contains(brick))
        {
            bricks.Remove(brick);
            Destroy(brick.gameObject);
            if(bricks.Count <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void SetGamePaused(bool value)
    {
        gamePaused = value;
        if(gamePaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        UIManager.Instance.SetPauseMenu(gamePaused);
    }
}
