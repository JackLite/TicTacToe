using System;
using System.IO;
using Menu;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class GameData
{
    public PlayersName playersName;
    public FieldSettings fieldSettings;
    public CellController.State[,] fieldState;
    public CellController.State lastState;
    public bool isExistGame;

    public static GameData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = DataManager.GetGameData();
            }

            return _instance;
        }
    }

    private static GameData _instance;

    public override string ToString()
    {
        var str = "Имена игроков: " + playersName.first + " " + playersName.second + "; Рзамеры поля: " +
                  fieldSettings.width + "x" + fieldSettings.height + "; Длина линни: " +
                  fieldSettings.winLine;
        str += "Предыдущая игра: " + Convert.ToInt16(isExistGame);
        return str;
    }

    public void SaveFieldState(CellController.State[,] fieldState)
    {
        this.fieldState = fieldState;
    }
}