using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public GameObject breakfastBurnt;
    private Color _spriteColor;
    public bool isShowering = false;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteColor = _spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if  (other.gameObject.name == "ƒуш")
            {
                StartCoroutine(breakfastBurnt.GetComponent<BreakfastBurnt>().BurnTimer());
                Debug.Log("ƒуш");
                Invisible();
            }
    }
    void Invisible()
    {
         isShowering = true;
         _spriteColor.a = 0f;
         _spriteRenderer.color = _spriteColor;
         GetComponent<PlayerController>().enabled = false;
         StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        _spriteColor.a = 1;
        _spriteRenderer.color = _spriteColor;
        StopCoroutine("Timer");
        GetComponent<PlayerController>().enabled = true;
    }
}
