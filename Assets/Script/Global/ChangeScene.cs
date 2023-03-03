using System.Collections;
using System.Collections.Generic;
using Script.Global;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneButton(string nameScene)
    {
        SceneLoadeManagers.Instance.Loads(nameScene);
    }
}
