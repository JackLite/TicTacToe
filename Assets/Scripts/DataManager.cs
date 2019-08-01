using UnityEngine;

public class DataManager : MonoBehaviour {
    private const string SavedJsonDataKey = "SavedJsonData";

    public static GameData GetGameData()
    {
        if(!PlayerPrefs.HasKey(SavedJsonDataKey))
        {
            var gameData = new GameData
            {
                fieldSettings = new FieldSettings(3), 
                playersName = new PlayersName("Игрок 1", "Игрок 2")
            };
            return gameData;
        }

        var json = PlayerPrefs.GetString(SavedJsonDataKey);
        var savedData = JsonUtility.FromJson<GameData>(json);
        
        return savedData;
    } 

    public static void SaveGameData()
    {
        var json = JsonUtility.ToJson(GameData.Instance);
        PlayerPrefs.SetString(SavedJsonDataKey, json);
    }

    public static void ClearGameData()
    {
        PlayerPrefs.DeleteKey(SavedJsonDataKey);
    }
	
}
