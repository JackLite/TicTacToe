using System.Collections;
using System.Collections.Generic;
using Game.Field;
using UnityEngine;
using UnityEngine.UI;

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

}
