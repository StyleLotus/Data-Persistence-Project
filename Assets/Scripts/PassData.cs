using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class PassData : MonoBehaviour
{
    public MainManager mainManager;

    public static PassData instance;
    public string playerName;
    public string newName;
    public int points;
    public string highscoreText;

    [SerializeField]public Text username_field;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);

        newName = username_field.text;

        Debug.Log(newName);

        LoadAll();
    }

    [System.Serializable]

    class SaveData
    {
        public string playerName;
        public int points;
        public string highscoreText;
    }
    public void SaveAll()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.points = points;
        data.highscoreText = highscoreText;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadAll()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            points = data.points;

            highscoreText = data.highscoreText;
        }
    }
}
