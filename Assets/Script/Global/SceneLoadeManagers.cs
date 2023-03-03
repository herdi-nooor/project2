using System.Threading.Tasks;
using Script.Global.DataPersisten;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Global
{
    public class SceneLoadeManagers : MonoBehaviour
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static SceneLoadeManagers Instance;
        [SerializeField] private GameObject loaderCanvas;

        private bool isMenuLoaded ;
        private string currentScene ;
        
        public void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Inits();
        }
    
        private void Inits()
        {
            isMenuLoaded = DataPersistenManager.isMenuLoaded;
            Debug.Log($"{isMenuLoaded} {DataPersistenManager.isMenuLoaded}");
            currentScene = SceneManager.GetActiveScene().name;
            CheckActiveScene();
        }

        private void CheckActiveScene()
        {
            if (currentScene != "MenuScene" && isMenuLoaded == false)
            {
                Loads("MenuScene");
                DataPersistenManager.isMenuLoaded = true;
                Debug.Log(SceneManager.GetActiveScene().name);
            }else if (currentScene == "MenuScene")
            {
                isMenuLoaded = true;
            }
        }

        public async void Loads(string newScene)
        {
            var scene = SceneManager.LoadSceneAsync(newScene);
            scene.allowSceneActivation = false;

            loaderCanvas.SetActive(true);
            do
            {
                await Task.Delay(1000);

            } while (scene.progress < 0.9f);

            scene.allowSceneActivation = true;
            await Task.Delay(100);
            loaderCanvas.SetActive(false);
        }

    }
}

