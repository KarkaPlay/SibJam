using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayerController: MonoBehaviour
{
    public float speed;

    public Sprite[] directions;
    private SpriteRenderer spriteRenderer;

    public GameObject pressEToInteract;
    private GameObject nearestInteractive;
    private DialogueTrigger trigger;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (nearestInteractive != null)
        {
            trigger = nearestInteractive.GetComponent<DialogueTrigger>();
            trigger.TriggerDialogue();
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
        if (other.gameObject.CompareTag("CanTalk"))
        {
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
