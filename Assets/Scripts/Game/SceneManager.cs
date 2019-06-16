using System.Collections;
using System.Collections.Generic;
using Game.Field;
using UnityEngine;
using UnityEngine.UI;

namespace TrueGames
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] public Sprite cell;
        [SerializeField] public Sprite cross;
        [SerializeField] public Sprite zero;
        [SerializeField] public GameObject GameField;
        [SerializeField] public GameObject GameScreen;
        [SerializeField] public GameObject EndGameScreen;
        [SerializeField] public GameObject WinTitleText;
        [SerializeField] public GameObject WinText;

        public GameObject LastCell { get; set; }

        public Sprite getCell()
        {
            return cell;
        }

        public Sprite getSprite(CellState state)
        {
            if (state == CellState.Cross)
            {
                return cross;
            }
            else if(state == CellState.Zero)
            {
                return zero;
            }
            else
            {
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
            GameScreen.SetActive(false);
            EndGameScreen.SetActive(true);
        }

        public void ReturnToMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.MenuSceneName);
        }
    }
}