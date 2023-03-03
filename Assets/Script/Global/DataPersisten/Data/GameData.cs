namespace Script.Global.DataPersisten.Data
{
    [System.Serializable]
    public class GameData
    {
        public int point;
        
        //the value dfine in this contstructor will be the default values
        // the game start with when there's no data to load
        public GameData()
        {
            this.point = 0;
        }
    }
}

