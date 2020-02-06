using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessPaddleModifier : Modifier
{
    [SerializeField]
    private float scaleDivider = 2f;
    [SerializeField]
    private float timeAffected = 5f;

    private float timeLeft;

    public override void Activate()
    {
        Paddle paddle = GameManager.Instance.GetPaddle();
        paddle.SetPaddleScale(paddle.GetDefaultScale() / scaleDivider);
        timeLeft = timeAffected;
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                DeActivate();
            }
        }
    }

    public override void DeActivate()
    {
        Paddle paddle = GameManager.Instance.GetPaddle();
        paddle.SetPaddleScale(paddle.GetDefaultScale());
        base.DeActivate();
    }
}
