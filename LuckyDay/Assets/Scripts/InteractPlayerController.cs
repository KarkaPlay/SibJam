using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlayerController : MonoBehaviour
{
    public float speed;
    public float height;
    public float bottomPoint;
    
    public Sprite[] directions;
    private SpriteRenderer spriteRenderer;

    public GameObject pressEToInteract;
    private GameObject nearestInteractive;
    private Interaction interaction;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        height = spriteRenderer.sprite.rect.height;
        height *= 0.16f;
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

        if (inputX >= 0 && inputY <= 0)
            spriteRenderer.sprite = directions[2]; // Down-Right
        else if (inputX >= 0 && inputY >= 0)
            spriteRenderer.sprite = directions[3]; // Up-Right
        else if (inputX <= 0 && inputY <= 0)
            spriteRenderer.sprite = directions[1]; // Down-Left
        else if (inputX <= 0 && inputY >= 0)
            spriteRenderer.sprite = directions[0]; // Up-Left

        height = spriteRenderer.sprite.rect.height / 16;
        bottomPoint = transform.position.y - height / 2;
        spriteRenderer.sortingOrder = -(int)(bottomPoint * 100);
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
