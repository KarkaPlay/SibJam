using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMoving : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D _collider2D;
    
    void Start()
    {
        float height = spriteRenderer.sprite.rect.height;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100);
        //_collider2D = GetComponent<Collider2D>();
        //spriteRenderer.sortingOrder = -(int) (_collider2D.transform.position.y * 100);
        spriteRenderer.sortingOrder -= (int)(height / 2.0f);
    }
    
}
