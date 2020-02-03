using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private AudioClip ballBrick;
    [SerializeField]
    private ParticleSystem brickParticlePrefab;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Ball>())
        {
            SoundManager.Instance.PlaySoundEffect(ballBrick);
            Camera.main.GetComponentInParent<CameraShaker>().Shake();
            ParticleSystem particles = Instantiate(brickParticlePrefab, transform.position + new Vector3(0f, 0f, -5f), brickParticlePrefab.transform.rotation);
            particles.Play();
            Destroy(particles.gameObject, particles.main.duration);
            GameManager.Instance.DestroyBrick(this);
        }
    }
}