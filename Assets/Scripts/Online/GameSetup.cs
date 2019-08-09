using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Online
{
    public class GameSetup : MonoBehaviour
    {
        public FieldSettings onlineFieldSettings;
        
        private void Start()
        {
            Network.EnemyFindEvent += OnEnemyFindEvent;
        }

        private void OnEnemyFindEvent()
        {
            StartOnlineGame();
        }

        public void StartOnlineGame()
        {
            GameData.Instance.fieldSettings = onlineFieldSettings;

            UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.GameSceneName);
            DataManager.SaveGameData();
        }

        public void SetPlayerNick(string nick)
        {
            GameManager.GetInstance().player.name = nick;
            GameData.Instance.onlineNickName = nick;
        }

        public void SetOnlineGameMode()
        {
            GameManager.GetInstance().gameMode = GameMode.Online;
        }
    }
}