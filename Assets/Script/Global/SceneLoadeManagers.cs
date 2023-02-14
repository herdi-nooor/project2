using System;
using System.Collections;
using System.Collections.Generic;
using LightFight.Global;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadeManagers : MonoBehaviour
{
    private bool isMenuLoaded = false;
    private void Awake()
    {
        isMenuLoaded = DataPersistenManager.isMenuLoaded;
        Debug.Log($"{isMenuLoaded} {DataPersistenManager.isMenuLoaded}");
        CheckActiveScene();
    }

    public void CheckActiveScene()
    {
        Scene activescene = SceneManager.GetActiveScene();
        if (activescene.name != "MenuScene" && isMenuLoaded == false)
        {
            Debug.Log($"active scenen {activescene.name}");
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            DataPersistenManager.isMenuLoaded = true;
            Load("MenuScene");
            Destroy(gameObject);
        }else if (activescene.name == "MenuScene")
        {
            Debug.Log($"active scenen {activescene.name}");
            isMenuLoaded = true;
            return;
        }
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
