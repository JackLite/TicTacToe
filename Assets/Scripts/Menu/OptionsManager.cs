using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class OptionsManager : MonoBehaviour
    {

        public InputField playerOneNickField;
        public InputField playerTwoNickField;
        public ScreensManager screensManager;

        private void Start()
        {
            var playersName = GameData.Instance.playersName;

            if (playersName.first == null || playersName.second == null) return;
            
            playerOneNickField.text = playersName.first;
            playerTwoNickField.text = playersName.second;
        }

        public void SaveButtonClick()
        {
            SaveOptions();
            screensManager.ShowMenu();
        }

        private void SaveOptions()
        {
            var playersManager = GameManager.GetInstance().gameObject.GetComponent<PlayersManager>();
            playersManager.playerOneName = playerOneNickField.text;
            playersManager.playerTwoName = playerTwoNickField.text;

            GameData.Instance.playersName.first = playersManager.playerOneName;
            GameData.Instance.playersName.second = playersManager.playerTwoName;
            DataManager.SaveGameData();
        }
    }
}