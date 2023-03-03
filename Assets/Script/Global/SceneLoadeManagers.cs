using Script.Global.DataPersisten;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadeManagers : MonoBehaviour
{
    private bool isMenuLoaded = false;
    private string currentScene = "";
    
    private void Awake()
    {
        isMenuLoaded = DataPersistenManager.isMenuLoaded;
        Debug.Log($"{isMenuLoaded} {DataPersistenManager.isMenuLoaded}");
        currentScene = SceneManager.GetActiveScene().name;
        CheckActiveScene();
    }

    private void CheckActiveScene()
    {
        UnityEngine.SceneManagement.Scene activescene = SceneManager.GetActiveScene();
        if (activescene.name != "MenuScene" && isMenuLoaded == false)
        {
            Debug.Log($"active scenen {activescene.name}");
            Loads("MenuScene");
            DataPersistenManager.isMenuLoaded = true;
            Debug.Log(SceneManager.GetActiveScene().name);
        }else if (activescene.name == "MenuScene")
        {
            Debug.Log($"active scenen {activescene.name}");
            isMenuLoaded = true;
            return;
        }
    }

    public void Loads(string NewScene)
    {
        SceneManager.LoadScene(NewScene, LoadSceneMode.Single);
        Debug.LogError(GameObject.Find(NewScene));
        SceneManager.UnloadScene(currentScene);
    }

}

