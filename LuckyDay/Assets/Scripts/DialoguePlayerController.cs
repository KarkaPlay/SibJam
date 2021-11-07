using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayerController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public GameObject pressEToInteract;
    private GameObject nearestInteractive;
    private DialogueTrigger trigger;

    public Animator animator;

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
