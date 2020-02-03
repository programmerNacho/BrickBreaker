using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBallsModifier : Modifier
{
    [SerializeField]
    private Ball ballPrefab;

    public override void Activate()
    {
        Paddle paddle = FindObjectOfType<Paddle>();
        Ball ball = Instantiate(ballPrefab, paddle.transform.position + new Vector3(0f, 1f), Quaternion.identity);
        DeActivate();
    }

    public override void DeActivate()
    {
        base.DeActivate();
    }
}
