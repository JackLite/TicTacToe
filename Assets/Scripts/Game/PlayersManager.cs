using System.Collections;
using System.Collections.Generic;
using Game.Field;
using UnityEngine;
using UnityEngine.UI;

public class PlayersManager : MonoBehaviour {

    public string playerOneName
    {
        get; set;
    }
    public string playerTwoName
    {
        get; set;
    }

    [SerializeField] GameObject playerPrefab;

    public string getWhoMoveNick(CellState state)
    {
        if(state == CellState.cross)
        {
            return GameData.Instance.playersName.first;
        }
        else if(state == CellState.zero)
        {
            return GameData.Instance.playersName.second;
        }
        else
        {
            return playerOneName;
        }
    }

}
