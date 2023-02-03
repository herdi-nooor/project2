using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LightFight.Global
{
    public class DataPersistenManager : MonoBehaviour
    {
        private GameData _gameData;
        public List<IDataPersistence> dataPersistenceObjects;

        private static DataPersistenManager instance { get; set; }
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("found more then one data persisten manager in the scane.");
            }

            instance = this;
        }

        public void Start()
        {
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
            // Todo - load any save data from a file using the data handler
            // if no data can be laoded, interface to a new game
            if (this._gameData == null)
            {
                Debug.Log("no data was found. Initiating data to defaults");
                NewGame();
            }
            //Todo - push the loaded data to all other scripts that need it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(_gameData);
            }
            
            Debug.Log("load data" + _gameData.point);
        }

        public void SaveGame()
        {
            // Todo - pass the data to other scripts so they can update it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.SaveData(ref _gameData);
            }
            Debug.Log("save data" + _gameData.point);
            
            // Todo - save that data to a file using the data handler
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }
    }
}
