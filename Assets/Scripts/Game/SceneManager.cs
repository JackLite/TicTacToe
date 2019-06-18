using Game.Field;
using UnityEngine;

namespace Game
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] public Sprite cross;
        [SerializeField] public Sprite zero;
        
        [SerializeField] 
        private GameObject gameScreen;
        
        [SerializeField] 
        private GameObject endGameScreen;

        public Sprite GetSprite(CellState state)
        {
            switch (state)
            {
                case CellState.Cross:
                    return cross;
                case CellState.Zero:
                    return zero;
                case CellState.Empty:
                    return null;
                default:
                    return null;
            }
        }

        private void Awake()
        {
            if(!GameManager.GetInstance())
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.MenuSceneName);
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ReturnToMenu();
            }
        }

        public void ShowWinner()
        {
            gameScreen.SetActive(false);
            endGameScreen.SetActive(true);
        }

        // ReSharper disable once MemberCanBeMadeStatic.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public void ReturnToMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.MenuSceneName);
        }
    }
}