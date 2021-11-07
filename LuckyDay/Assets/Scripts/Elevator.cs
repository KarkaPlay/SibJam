using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Elevator : MonoBehaviour
{
    public GameObject elevatorMenuUI;

    private GameObject nearestInteractive;
    public static bool isElevatorWindowOn = false;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject choice4;

    public int sceneid;
    private Save sv = new Save();
    private string path;

    private void Start()
    {
        path = Path.Combine(Application.dataPath, "Save.json");//считывание
        if (File.Exists(path))//проверка данных в файле
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            Debug.Log("Well" + sv.sceneid);
        }

    }

    void ElevatorWindowOn()
    {
        elevatorMenuUI.SetActive(true);
        isElevatorWindowOn = true;
    }
    void ElevatorWindowOff()
    {
        elevatorMenuUI.SetActive(false);
        isElevatorWindowOn = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elevator"))
        {
            nearestInteractive = other.gameObject;
            elevatorMenuUI.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        elevatorMenuUI.SetActive(false);
        nearestInteractive = null;
    }
    public void ChoiceOption1 ()
    {
        sceneid = 4;
        CheckData(sceneid);
        SceneManager.LoadScene("Warehouse");
    }

    public void ChoiceOption2()
    {
        sceneid = 2;
        CheckData(sceneid);
        SceneManager.LoadScene("Hall");
    }

    public void ChoiceOption3()
    {
        sceneid = 5;
        CheckData(sceneid);
        SceneManager.LoadScene("Corridor");
    }
    public void ChoiceOption4()
    {
        sceneid = 3;
        CheckData(sceneid);
        SceneManager.LoadScene("Boss room");
    }
    [Serializable]
    public class Save
    {
        public int sceneid;
    }
    public void CheckData(int sceneid)//запись данных
    {
        sv.sceneid = sceneid;
        Debug.Log("Well" + sv.sceneid);
    }
}


