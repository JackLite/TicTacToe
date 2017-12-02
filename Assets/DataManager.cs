using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization; 
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour {

    private string playersFileName = "/players.data";
    private string playersFilePath;

    private void Awake()
    {
        playersFilePath = Application.persistentDataPath + playersFileName;
    }

    public GameData GetGameData()
    {
        if(!File.Exists(Application.persistentDataPath + playersFileName))
        {
            return GameData.Instance;
        }
        IFormatter formatter = new BinaryFormatter();
        FileStream buffer = File.OpenRead(Application.persistentDataPath + playersFileName);
        GameData savedData = formatter.Deserialize(buffer) as GameData;
        buffer.Close();
        return savedData;
    } 

    public void SaveGameData()
    {
        IFormatter formatter = new BinaryFormatter();
        FileStream buffer = File.Create(Application.persistentDataPath + playersFileName);
        formatter.Serialize(buffer, GameData.Instance);
        buffer.Close();
    }
	
}
