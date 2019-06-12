using System;
using System.IO;
using Menu;
using UnityEngine;

[Serializable]
public class GameData
{
    public PlayersName playersName;
    public int fieldWidth = 3;
    public int fieldHeight = 3;
    public int winLine = 3;
    public CellController.State[,] fieldState;
    public CellController.State lastState;
    public bool isExistGame;
    public float positionX;
    public float positionY;

    public static GameData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameManager.Instance.GetComponent<DataManager>().GetGameData();
            }

            return _instance;
        }
    }

    private static GameData _instance;

    public override string ToString()
    {
        var str = "Имена игроков: " + playersName.first + " " + playersName.second + "; Рзамеры поля: " +
                  fieldWidth + "x" + fieldHeight + "; Длина линни: " + winLine;
        str += "Предыдущая игра: " + Convert.ToInt16(isExistGame);
        return str;
    }
}