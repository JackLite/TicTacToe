using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{

    private string playersFileName = "/game.data";
    private string playersFilePath;

    private void Awake()
    {
        playersFilePath = Application.persistentDataPath + playersFileName;
    }

    public GameData GetGameData()
    {
        if (!File.Exists(Application.persistentDataPath + playersFileName))
        {
            return new GameData();
        }
        GameData savedData;
        try
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream buffer = File.OpenRead(Application.persistentDataPath + playersFileName);
            savedData = formatter.Deserialize(buffer) as GameData;
            buffer.Close();
        }
        catch (EndOfStreamException e)
        {
            Debug.Log(e.Message);
            savedData = new GameData();
        }
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