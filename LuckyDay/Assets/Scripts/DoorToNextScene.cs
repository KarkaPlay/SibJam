using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextScene : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _spriteColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Дверь наружу")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
