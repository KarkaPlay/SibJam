using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayerController : MonoBehaviour
{
    public float speed;
    
    public Sprite[] directions;
    private SpriteRenderer spriteRenderer;

    public GameObject pressEToInteract;
    private GameObject nearestInteractive;
    private Interaction interaction;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (nearestInteractive != null)
        {
            interaction = nearestInteractive.GetComponent<Interaction>();
            interaction.Interact();
        }
    }
    
    void FixedUpdate()
    {
        //if isGameActive
        MovePlayer();
    }
    
    void MovePlayer()
    {
        // Перемещение
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * (inputX * speed * Time.fixedDeltaTime), Space.World);
        transform.Translate(Vector2.up * (inputY * speed * Time.fixedDeltaTime), Space.World);

        if (inputX > 0.2)
            spriteRenderer.sprite = directions[3]; // Right
        else if (inputX < -0.2)
            spriteRenderer.sprite = directions[1]; // Left
        else if (inputY > 0.2)
            spriteRenderer.sprite = directions[2]; // Up
        else if (inputY < -0.2)
            spriteRenderer.sprite = directions[0]; // Down
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactive"))
        {
            nearestInteractive = other.gameObject;
            pressEToInteract.SetActive(true);
        }
        if (other.gameObject.CompareTag("CanTalk"))
        {
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            nearestInteractive = other.gameObject;
            pressEToInteract.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        pressEToInteract.SetActive(false);
        nearestInteractive = null;
    }
}
