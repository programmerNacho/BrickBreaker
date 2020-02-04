using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierBall : MonoBehaviour
{
    [SerializeField]
    private Modifier modifierPrefab;

    private void Start()
    {
        Destroy(gameObject, 3f);
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
