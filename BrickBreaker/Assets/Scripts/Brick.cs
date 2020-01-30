using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Ball>())
        {
            GameManager.Instance.DestroyBrick(this);
        }
    }
}