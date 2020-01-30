using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 8f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float spriteWidth = spriteRenderer.bounds.size.x;
        Boundaries.CameraWorldBounds cameraWorldBounds = Boundaries.GetCameraWorldBounds();
        float minX = cameraWorldBounds.minX + spriteWidth / 2f;
        float maxX = cameraWorldBounds.maxX - spriteWidth / 2f;
        Vector3 targetPosition = transform.position;
        targetPosition.x += Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        transform.position = targetPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Ball>())
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            Vector2 maxDirectionLeft = (Vector2.up + -Vector2.right).normalized;
            Vector2 maxDirectionRight = (Vector2.up + Vector2.right).normalized;
            float leftSideX = spriteRenderer.bounds.min.x;
            float rightSideX = spriteRenderer.bounds.max.x;
            float maxDistanceX = Mathf.Abs(rightSideX - leftSideX);
            float ballDistanceToLeftSide = Mathf.Abs(ball.transform.position.x - leftSideX);
            ball.SetMovementDirection(Vector2.Lerp(maxDirectionLeft, maxDirectionRight, ballDistanceToLeftSide / maxDistanceX).normalized);
        }
    }
}