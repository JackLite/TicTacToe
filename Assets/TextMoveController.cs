using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveController : MonoBehaviour {

    private string whoMoveTpl = "Ходит {name}";

    [SerializeField] GameObject WhoMoveText;

    private void Awake()
    {
        changeWhoMove(CellController.State.empty);
    }

    public void changeWhoMove(CellController.State state)
    {
        string text = whoMoveTpl.Replace("{name}", GameManager.getInstance().GetComponent<PlayersManager>().getWhoMoveNick(state));
        WhoMoveText.GetComponent<Text>().text = text;
    }
}
