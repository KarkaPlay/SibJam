using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Sprite turnedOn, turnedOff;
    private SpriteRenderer _spriteRenderer;
    public int counter;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = turnedOff;
    }

    public void Interact()
    {
        if (_spriteRenderer.sprite == turnedOff)
        {
             counter++;
            _spriteRenderer.sprite = turnedOn;
        }
        else
        {
            _spriteRenderer.sprite = turnedOff;
        }
    }
}
