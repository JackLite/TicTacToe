using Game.Field;
using UnityEngine;
using UnityEngine.UI;

public class TextMoveController : MonoBehaviour {

    [SerializeField] 
    private Text whoMoveText;

    public void ChangeWhoMove(CellState state)
    {
        var text = PlayersManager.GetWhoMoveNick(state);
        whoMoveText.text = text;
    }
}
