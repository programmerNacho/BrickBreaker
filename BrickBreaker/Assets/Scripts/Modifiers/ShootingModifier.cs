using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModifier : Modifier
{
    [SerializeField]
    private Bullet bulletPrefab;
    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private int numberOfShoots = 5;

    private float timeLeft = 0f;

    public override void Activate()
    {
        timeLeft = 0.01f;
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Paddle paddle = GameManager.Instance.GetPaddle();
                Instantiate(bulletPrefab, paddle.transform.position + new Vector3(0f, 1f), bulletPrefab.transform.rotation);
                numberOfShoots--;
                timeLeft = fireRate;
                if (numberOfShoots <= 0)
                {
                    DeActivate();
                }
            }
        }
    }

    public override void DeActivate()
    {
        base.DeActivate();
    }
}
