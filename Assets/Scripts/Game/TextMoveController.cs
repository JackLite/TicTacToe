using Game.Field;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveController : MonoBehaviour {

    [SerializeField] 
    private Text whoMoveText;

    public void ChangeWhoMove(CellState state)
    {
        var text = GameManager.GetInstance().GetComponent<PlayersManager>().getWhoMoveNick(state);
        whoMoveText.text = text;
    }
}
