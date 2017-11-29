using System.Collections;
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
            return playerOneName;
        }
        else if(state == CellController.State.zero)
        {
            return playerTwoName;
        }
        else
        {
            return playerOneName;
        }
    }

}
