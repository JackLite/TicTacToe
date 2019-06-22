using Game.Field;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public static string GetWhoMoveNick(CellState state)
    {
        switch (state)
        {
            case CellState.Cross:
                return GameData.Instance.playersName.first;
            case CellState.Zero:
                return GameData.Instance.playersName.second;
            case CellState.Empty:
                return GameData.Instance.playersName.first;
            default:
                return GameData.Instance.playersName.first;
        }
    }
    
    public static string GetWinnerName(CellState state)
    {
        switch (state)
        {
            case CellState.Cross:
                return GameData.Instance.playersName.first;
            case CellState.Zero:
                return GameData.Instance.playersName.second;
            case CellState.Empty:
                throw new System.Exception("Передано неверное состояние");
            default:
                throw new System.Exception("Передано неверное состояние");
        }
    }
}
