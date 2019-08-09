using Game.Field;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class TextMoveController : MonoBehaviour
    {
        [SerializeField]
        private Text whoMoveText;

        private void Start()
        {
            Online.OnlineStepManager.textMove = this;
        }

        public void ChangeWhoMove(CellState state)
        {
            var text = PlayersManager.GetWhoMoveNick(state);
            Debug.Log(text);
            whoMoveText.text = text;
        }
    }
}