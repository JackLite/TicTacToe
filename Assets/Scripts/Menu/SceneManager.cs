using UnityEngine;

namespace Menu
{
    public class SceneManager : MonoBehaviour
    {
        public PreGameOptionsManager preGameOptionsManager;

        public void StartGame()
        {
            GameManager.GetInstance().isResumeGame = false;
            preGameOptionsManager.SetParams();
            LoadGameScene();
        }

        public void ContinueGame()
        {
            GameManager.GetInstance().isResumeGame = true;
            LoadGameScene();
        }

        private static void LoadGameScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.GameSceneName);
            GameData.Instance.isExistGame = true;
        }
    }
}