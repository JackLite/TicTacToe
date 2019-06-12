using UnityEngine;
using System.IO;
using System.Runtime.Serialization; 
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour {
    private const string PlayersFileName = "/game.data";

    public static GameData GetGameData()
    {
        if(!File.Exists(Application.persistentDataPath + PlayersFileName))
        {
            var gameData = new GameData
            {
                fieldSettings = new FieldSettings(3), 
                playersName = new PlayersName("Игрок 1", "Игрок 2")
            };
            return gameData;
        }
        GameData savedData;
        try
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream buffer = File.OpenRead(Application.persistentDataPath + PlayersFileName);
            savedData = formatter.Deserialize(buffer) as GameData;
            buffer.Close();
        } catch (EndOfStreamException e)
        {
            Debug.Log(e.Message);
            savedData = new GameData();
        }
        return savedData;
    } 

    public static void SaveGameData()
    {
        IFormatter formatter = new BinaryFormatter();
        FileStream buffer = File.Create(Application.persistentDataPath + PlayersFileName);
        formatter.Serialize(buffer, GameData.Instance);
        buffer.Close();
    }

    public static void ClearGameData()
    {
        File.Delete(Application.persistentDataPath + PlayersFileName);
    }
	
}
