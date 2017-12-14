﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TrueGames
{
    public class SceneManager : MonoBehaviour
    {
        private GameObject lastCell;

        [SerializeField] public Sprite cell;
        [SerializeField] public Sprite cross;
        [SerializeField] public Sprite zero;
        [SerializeField] public GameObject AI;
        [SerializeField] public GameObject GameField;
        [SerializeField] public GameObject GameScreen;
        [SerializeField] public GameObject EndGameScreen;
        [SerializeField] public GameObject WinTitleText;
        [SerializeField] public GameObject WinText;

        public GameObject LastCell
        {
            get
            {
                return lastCell;
            }
            set
            {
                lastCell = value;
            }
        }

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
                return new Sprite();
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.getInstance().ExitToMenu();
            }
        }

        public void ShowWinner()
        {
            GameScreen.SetActive(false);
            EndGameScreen.SetActive(true);
        }

        public void returnToMenu()
        {
            GameManager.getInstance().ExitToMenu();
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