using System.Collections;
using System.Collections.Generic;
using Game.Field;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveController : MonoBehaviour {

    [SerializeField] GameObject WhoMoveText;

    private void Start()
    {
        if(GameData.Instance.isExistGame && GameManager.GetInstance().isResumeGame)
        {
            if(GameData.Instance.lastState == CellState.cross)
            {
                changeWhoMove(CellState.zero);
            }
            else
            {
                changeWhoMove(CellState.cross);
            }
        }
        else
        {
            changeWhoMove(CellState.empty);
        }
    }

    public void changeWhoMove(CellState state)
    {
        string text = GameManager.GetInstance().GetComponent<PlayersManager>().getWhoMoveNick(state);
        WhoMoveText.GetComponent<Text>().text = text;
    }
}
