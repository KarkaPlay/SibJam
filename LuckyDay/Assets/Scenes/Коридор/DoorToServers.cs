using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToServers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Дверь в серверную")
        {
            SceneManager.LoadScene("Servers room");
        }
    }

}

