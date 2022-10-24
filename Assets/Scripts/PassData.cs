using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassData : MonoBehaviour
{
    public static PassData instance;
    public string playerName;

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
    }
}
