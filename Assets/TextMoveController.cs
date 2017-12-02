using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveController : MonoBehaviour {

    private string whoMoveTpl = "Ходит {name}";

    [SerializeField] GameObject WhoMoveText;

    private void Awake()
    {
        if(GameData.Instance.isExistGame && GameManager.Instance.isResumeGame)
        {
            if(GameData.Instance.lastState == CellController.State.cross)
            {
                changeWhoMove(CellController.State.zero);
            }
            else
            {
                changeWhoMove(CellController.State.cross);
            }
        }
        else
        {
            changeWhoMove(CellController.State.empty);
        }
    }

    public void changeWhoMove(CellController.State state)
    {
        string text = whoMoveTpl.Replace("{name}", GameManager.getInstance().GetComponent<PlayersManager>().getWhoMoveNick(state));
        WhoMoveText.GetComponent<Text>().text = text;
    }
}
