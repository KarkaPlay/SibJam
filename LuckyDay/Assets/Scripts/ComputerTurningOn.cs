using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTurningOn : MonoBehaviour
{
    public Sprite turnedOn, turnedOff;
    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = turnedOff;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState()
    {
        _spriteRenderer.sprite = _spriteRenderer.sprite == turnedOff ? turnedOn : turnedOff;
    }
}
