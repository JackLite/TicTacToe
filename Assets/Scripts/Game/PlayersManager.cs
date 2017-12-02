﻿using System.Collections;
using System.Collections.Generic;
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

    public string getWhoMoveNick(CellController.State state)
    {
        if(state == CellController.State.cross)
        {
            return GameData.Instance.playersName[0];
        }
        else if(state == CellController.State.zero)
        {
            return GameData.Instance.playersName[1];
        }
        else
        {
            return playerOneName;
        }
    }

}
