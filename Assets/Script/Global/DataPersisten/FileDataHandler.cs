using System;
using System.IO;
using UnityEngine;

namespace LightFight.Global
{
    public class FileDataHandler
    {
        private string dataDirPath = "";
        private string dataFileName = "";

        public FileDataHandler(string dataDirPath, string dataFileName)
        {
            this.dataDirPath = dataDirPath;
            this.dataFileName = dataFileName;
        }

        public GameData Load()
        {
            string fullPath = Path.Combine(dataDirPath, dataFileName);
            GameData loadedData = null;
            if (File.Exists(fullPath))
            {
                try
                {
                    // load the serialized data from the file
                    string dataToLoad = "";
                    using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }
                    
                    // deserialize the data from json back into the c# object
                    loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                }
                catch (Exception e)
                {
                    Debug.LogError("Error occured when traying to lad data form file: "+ fullPath +"\n"+ e);
                }
            }
            return loadedData;
        }

        public void Save(GameData data)
        {
            // use Path.Combine to account for differen OS's having different path separator
            string fullPath = Path.Combine(dataDirPath, dataFileName);
            try
            {
                // create the directory the file will be eritten to if it doesn't already exist
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                
                //serialize the c# game data objec into json
                string dataToStore = JsonUtility.ToJson(data, true);
                
                // write the serialize data to the file
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(dataToStore);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when traying to save data to file: "+ fullPath+"\n"+ e);
            }
        }
        
    }
}