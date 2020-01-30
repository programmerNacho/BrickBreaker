using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float movementImpulse = 5f;
    [SerializeField]
    private Vector2 initialMovementDirection = Vector2.up;

    private Vector2 movementDirection;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        movementDirection = initialMovementDirection.normalized;
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(movementDirection * movementImpulse, ForceMode2D.Impulse);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Bounds spriteBounds = spriteRenderer.bounds;
        Boundaries.CameraWorldBounds cameraWorldBounds = Boundaries.GetCameraWorldBounds();
        float minX = cameraWorldBounds.minX + spriteBounds.size.x / 2f;
        float maxX = cameraWorldBounds.maxX - spriteBounds.size.x / 2f;
        float minY = cameraWorldBounds.minY + spriteBounds.size.y / 2f;
        float maxY = cameraWorldBounds.maxY - spriteBounds.size.y / 2f;

        if(transform.position.x < minX)
        {
            movementDirection = rigidbody2D.velocity.normalized;
            movementDirection.x *= -1f;
            Vector2 targetPosition = transform.position;
            targetPosition.x = minX;
            transform.position = targetPosition;
            SetMovementDirection(movementDirection);
        }
        else if(transform.position.x > maxX)
        {
            movementDirection = rigidbody2D.velocity.normalized;
            movementDirection.x *= -1f;
            Vector2 targetPosition = transform.position;
            targetPosition.x = maxX;
            transform.position = targetPosition;
            SetMovementDirection(movementDirection);
        }
        else if(transform.position.y > maxY)
        {
            movementDirection = rigidbody2D.velocity.normalized;
            movementDirection.y *= -1f;
            Vector2 targetPosition = transform.position;
            targetPosition.y = maxY;
            transform.position = targetPosition;
            SetMovementDirection(movementDirection);
        }
        else if(transform.position.y < minY)
        {
            GameManager.Instance.DestroyBall(this);
        }

        movementDirection = rigidbody2D.velocity.normalized;
    }

    public Vector2 GetMovementDirection()
    {
        return movementDirection;
    }

    public void SetMovementDirection(Vector2 movementDirection)
    {
        this.movementDirection = movementDirection.normalized;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(this.movementDirection * movementImpulse, ForceMode2D.Impulse);
    }
}
