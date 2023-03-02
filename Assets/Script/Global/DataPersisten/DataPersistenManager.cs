using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LightFight.Global
{
    public class DataPersistenManager : MonoBehaviour
    {
        [Header("File Strorage Config")]
        [SerializeField] private string filename;
        
        private GameData _gameData;
        private List<IDataPersistence> dataPersistenceObjects;
        private FileDataHandler _dataHandler;
        [HideInInspector] public static bool isMenuLoaded = false;

        private static DataPersistenManager instance { get; set; }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.Log("found more then one data persisten manager in the scane.");
                Destroy(gameObject);
            }
        }

        public void Start()
        {
            this._dataHandler = new FileDataHandler(Application.persistentDataPath, filename);
            this.dataPersistenceObjects = FindAllDataPersistenceObject();
            LoadGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObject()
        {
            IEnumerable<IDataPersistence> dataPersistencesObjects =
                FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataPersistencesObjects);
        }

        public void NewGame()
        {
            this._gameData = new GameData();
        }

        public void LoadGame()
        {
            // load any save data from a file using the data handler
            this._gameData = _dataHandler.Load();
            
            // if no data can be laoded, interface to a new game
            if (this._gameData == null)
            {
                Debug.Log("no data was found. Initiating data to defaults");
                NewGame();
            }
            //push the loaded data to all other scripts that need it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(_gameData);
            }
            
        }

        public void SaveGame()
        {
            //pass the data to other scripts so they can update it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.SaveData(ref _gameData);
            }
            
            //save that data to a file using the data handler
            _dataHandler.Save(_gameData);
        }

        private void OnApplicationQuit()
        {
            SaveGame();
            isMenuLoaded = false;
        }
    }
}
