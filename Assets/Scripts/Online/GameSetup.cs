using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Online
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
            GameManager.GetInstance().gameMode = GameMode.Online;
            
            SceneManager.LoadScene(GameManager.GameSceneName);
        }
    }
}