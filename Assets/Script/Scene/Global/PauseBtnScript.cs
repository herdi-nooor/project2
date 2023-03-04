using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtnScript : MonoBehaviour
{
    [SerializeField] private GameObject PauseBtn;
    [SerializeField] private GameObject PnaelPause;
    private bool pause;

    public void Pause()
    {
        Time.timeScale = 0;
        PauseBtn.SetActive(false);
        PnaelPause.SetActive(true);
    }

    public void Recume()
    {
        PnaelPause.SetActive(false);
        PauseBtn.SetActive(true);
        Time.timeScale = 1;
    }
}
