using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTurningOn : MonoBehaviour // переименовать в Interaction и называть так для всех предметов
{
    public Sprite turnedOn, turnedOff;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeState()
    {
        if (_spriteRenderer.sprite == turnedOff)
        {
            _spriteRenderer.sprite = turnedOn;
            Debug.Log("комп вкл");
        }
        else
        {
            _spriteRenderer.sprite = turnedOff;
            Debug.Log("комп выкл");
        }
    }
}
