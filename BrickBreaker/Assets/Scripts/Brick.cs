using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private AudioClip ballBrick;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Ball>())
        {
            SoundManager.Instance.PlaySoundEffect(ballBrick);
            Camera.main.GetComponentInParent<CameraShaker>().Shake();
            GameManager.Instance.DestroyBrick(this);
        }
    }
}