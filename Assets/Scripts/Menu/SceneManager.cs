using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class SceneManager : MonoBehaviour
    {
        public PreGameOptionsManager preGameOptionsManager;

        public void StartGame()
        {
            GameManager.Instance.isResumeGame = false;
            preGameOptionsManager.SetParams();
            LoadGameScene();
        }

        public void ContinueGame()
        {
            GameManager.Instance.isResumeGame = true;
            LoadGameScene();
        }

        private static void LoadGameScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.Instance.GameSceneName);
            GameData.Instance.isExistGame = true;
        }
    }
}