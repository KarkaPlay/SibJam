using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakfastBurnt : MonoBehaviour
{
    public Sprite burnt;
    public GameObject player;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void IsBurned()
    {
        _spriteRenderer.sprite = burnt;
    }
    public IEnumerator BurnTimer()
    {
        yield return new WaitForSeconds(3);
        IsBurned();
    }
}
