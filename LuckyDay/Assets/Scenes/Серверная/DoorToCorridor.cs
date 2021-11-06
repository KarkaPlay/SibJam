using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DoorToCorridor : MonoBehaviour
{
    public GameObject vPlayer;
    public int timetoStop;

    public void Start()
    {
        vPlayer.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Дверь в коридор")
        {
            vPlayer.SetActive(true);
        }
    }

}

