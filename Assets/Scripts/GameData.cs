using System;
using System.IO;
using UnityEngine;

[Serializable]
public class GameData
{
    public string[] playersName = new string[2];
    public int fieldWidth;
    public int fieldHeight;
    public int winLine;
    public CellController.State[,] fieldState;
    public CellController.State lastState;
    public bool isExistGame = false;

    public static GameData Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameManager.Instance.GetComponent<DataManager>().GetGameData();
            }
            return instance;
        }
    }
    private static GameData instance = null;

    public override string ToString()
    {
        string str = "Имена игроков: " + playersName.ToString() + "; Рзамеры поля: " + fieldWidth + "x" + fieldHeight + "; Длина линни: " + winLine;
        str += "Предыдущая игра: " + Convert.ToInt16(isExistGame);
        return str;
    }
}