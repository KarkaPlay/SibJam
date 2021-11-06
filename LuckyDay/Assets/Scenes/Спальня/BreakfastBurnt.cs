using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakfastBurnt : MonoBehaviour
{
    public Sprite burnt;
    public GameObject player;
    private SpriteRenderer _spriteRenderer;
    public Interaction interaction;
    void Start()
    {
         interaction = gameObject.GetComponent<Interaction>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void IsBurned()
    {
        if (interaction.counter < 5 && interaction.turnedOff != null)
        _spriteRenderer.sprite = burnt;
    }
    public IEnumerator BurnTimer()
    {
        yield return new WaitForSeconds(3);
        IsBurned();
    }
}
