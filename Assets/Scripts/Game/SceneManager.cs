using System.Collections;
using System.Collections.Generic;
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

        public Sprite getSprite(CellController.State state)
        {
            if (state == CellController.State.cross)
            {
                return cross;
            }
            else if(state == CellController.State.zero)
            {
                return zero;
            }
            else
            {
                return null;
            }
        }

        private void Start()
        {
            if(!GameManager.Instance)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.GameSceneName);
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

        private static void ReturnToMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(GameManager.MenuSceneName);
        }

        public void resetLastCell()
        {
            if (
                LastCell is GameObject
                && LastCell.GetComponent<CellController>().Choosen
                && LastCell.GetComponent<CellController>().currentState == CellController.State.empty
                )
            {
                LastCell.transform.transform.Find(CellController.childName).GetComponent<Image>().color = new Color(0, 0, 0, 0);
                LastCell.GetComponent<CellController>().Choosen = false;
            }
        }
    }
}