using Game.Field;
using UnityEngine;
using Game.Online;
using Network = Game.Online.Network;

public class PlayersManager : MonoBehaviour
{
    public static string GetWhoMoveNick(CellState state)
    {
        if (GameManager.GetInstance().gameMode == GameMode.Online)
        {
            return GetOnlineNick(state);
        }
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

    private static string GetOnlineNick(CellState state)
    {
        var playerType = StateHelper.Convert(state);
        Core.Player currentPlayer = GameManager.GetInstance().player;
        if (playerType == currentPlayer.playerType)
        {
            return currentPlayer.name;
        }
        else
        {
            return Network.enemyNickName;
        }
    }
    
    public static string GetWinnerName(CellState state)
    {
        if (GameManager.GetInstance().gameMode == GameMode.Online)
        {
            return GetOnlineNick(state);
        }
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
