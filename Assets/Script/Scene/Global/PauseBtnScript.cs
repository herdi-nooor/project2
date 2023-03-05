using System.Collections;
using System.Collections.Generic;
using Script.Global;
using UnityEditor.VersionControl;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

public class PauseBtnScript : MonoBehaviour
{
    [SerializeField] private GameObject PauseBtn;
    [SerializeField] private GameObject PnaelPause;
    private bool pause;
    private GameObject buttonPouse;
    
    public void Pause()
    {
        Time.timeScale = 0;
        PnaelPause.SetActive(true);
    }

    public async void Recume()
    {
        await Task.Delay(990);
        Time.timeScale = 1;
        PnaelPause.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneLoadeManagers.Instance.Loads("MenuScene");
    }

    public void Restart(string nameScene)
    {
        //restart gameplay
        Time.timeScale = 1;
        SceneLoadeManagers.Instance.Loads(nameScene);
    }

}
