using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextScene : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _spriteColor;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteColor = _spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Дверь наружу")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Invisible();
        }
    }

    void Invisible()
    {
        _spriteColor.a = 0f;
        _spriteRenderer.color = _spriteColor;
        GetComponent<InteractPlayerController>().enabled = false;
    }
}
