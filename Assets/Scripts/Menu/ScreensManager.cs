using System;
using UnityEngine;

namespace Menu
{
    public class ScreensManager : MonoBehaviour
    {
        public GameObject menu;
        public GameObject preGameOptions;
        public GameObject options;
        public GameObject authors;

        private GameObject currentActiveScreen;

        private void Start()
        {
            currentActiveScreen = menu;
        }

        public void ShowOptions()
        {
            ShowScreen(options);
        }

        public void ShowPreGameOptions()
        {
            ShowScreen(preGameOptions);
        }

        public void ShowAutors()
        {
            ShowScreen(authors);
        }

        public void ShowMenu()
        {
            ShowScreen(menu);
        }

        private void Update()
        {
            if (!Input.GetKey(KeyCode.Escape)) return;
            
            if (currentActiveScreen.name != "MainMenu")
            {
                ShowMenu();
            }
            else
            {
                Application.Quit();
            }
        }

        public void ShowScreen(GameObject screen)
        {
            currentActiveScreen.SetActive(false);
            screen.SetActive(true);
            currentActiveScreen = screen;
        }
    }
}