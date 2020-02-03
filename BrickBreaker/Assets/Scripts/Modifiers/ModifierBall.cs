using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierBall : MonoBehaviour
{
    [SerializeField]
    private Modifier modifierPrefab;
    [SerializeField]
    private Sprite modifierSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = modifierSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Paddle>())
        {
            ModifierSystem.Instance.AddModifier(modifierPrefab);
            Destroy(gameObject);
        }
    }
}
