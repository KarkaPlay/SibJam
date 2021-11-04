using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    public Sprite[] directions;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if isGameActive
        MovePlayer();
    }
    
    void MovePlayer()
    {
        // Перемещение
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * (inputX * speed * Time.fixedDeltaTime), Space.World);
        transform.Translate(Vector2.up * (inputY * speed * Time.fixedDeltaTime), Space.World);

        if (inputX > 0.5)
            spriteRenderer.sprite = directions[3]; // Right
        else if (inputX < -0.5)
            spriteRenderer.sprite = directions[1]; // Left
        else if (inputY > 0.5)
            spriteRenderer.sprite = directions[2]; // Up
        else if (inputY < -0.5)
            spriteRenderer.sprite = directions[0]; // Down
    }
}
