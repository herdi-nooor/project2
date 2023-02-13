using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadeManagers : MonoBehaviour
{
    private void Awake()
    {
        CheckActiveScene();
    }

    public void CheckActiveScene()
    {
        Scene activescene = SceneManager.GetActiveScene();
        if (activescene.name != "MenuScene")
        {
            Debug.Log($"active scenen {activescene.name}");
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            Load("MenuScene");
        }else if (activescene.name == "MenuScene")
        {
            Debug.Log($"active scenen {activescene.name}");
            return;
        }
        else
        {
            Debug.LogError("something wrong");
        }
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
