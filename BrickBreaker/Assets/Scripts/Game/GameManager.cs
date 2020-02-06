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
    private Paddle paddle;

    private bool gamePaused = false;
    private bool gameFinished = false;

    private void Start()
    {
        balls = new List<Ball>(FindObjectsOfType<Ball>());
        bricks = new List<Brick>(FindObjectsOfType<Brick>());
        paddle = FindObjectOfType<Paddle>();
        gamePaused = false;
        gameFinished = false;
        SetGamePaused(gamePaused);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !gameFinished)
        {
            SetGamePaused(!gamePaused);
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public Paddle GetPaddle()
    {
        return paddle;
    }

    public void AddBall(Ball ball)
    {
        balls.Add(ball);
    }

    public void DestroyBall(Ball ball)
    {
        if(balls.Contains(ball))
        {
            balls.Remove(ball);
            Destroy(ball.gameObject);
            if(balls.Count <= 0)
            {
                Time.timeScale = 0f;
                gameFinished = true;
                UIManager.Instance.GameFinished(false);
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
                Time.timeScale = 0f;
                gameFinished = true;
                UIManager.Instance.GameFinished(true);
                LevelManager.Instance.LevelCompleted(SceneManager.GetActiveScene().name);
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
