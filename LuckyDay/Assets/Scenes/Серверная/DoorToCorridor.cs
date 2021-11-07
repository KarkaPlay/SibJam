using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToCorridor : MonoBehaviour
{
    public GameObject vPLayer;
    private void Start()
    {
        vPLayer.SetActive(false);
    }
    //public int timeToStop;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.name == "Дверь в коридор")
        {
            vPLayer.SetActive(true);

        }
    }
}

