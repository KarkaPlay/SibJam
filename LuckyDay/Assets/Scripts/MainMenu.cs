using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public int sceneid;

    private Save sv = new Save();
    private string path;
    public void PlayGame()
    {
        path = Path.Combine(Application.dataPath, "Save.json");//считывание
        if (File.Exists(path))//проверка данных в файле
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            Debug.Log("Well" + sv.sceneid);
        }
        sceneid = sv.sceneid;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    [Serializable]
    public class Save
    {
        public int sceneid;
    }
}