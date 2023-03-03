using Script.Global.DataPersisten.Data;

namespace Script.Global.DataPersisten
{
    public interface IDataPersistence
    {
        void LoadData(GameData data);
        void SaveData(ref GameData data);
    }
}