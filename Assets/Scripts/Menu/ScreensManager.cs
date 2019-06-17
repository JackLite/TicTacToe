using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class ScreensManager : MonoBehaviour
    {
        public GameObject menu;
        public GameObject preGameOptions;
        public GameObject options;
        public GameObject autors;
        public enum State { menu, preGameOptions, options, autors };

        private State currentState = State.menu;

        public void ShowOptions()
        {
            menu.SetActive(false);
            ChangeState(State.options);
        }

        public void ShowPreGameOptions()
        {
            menu.SetActive(false);
            ChangeState(State.preGameOptions);
        }

        public void ShowAutors()
        {
            menu.SetActive(false);
            ChangeState(State.autors);
        }

        public void ShowMenu()
        {
            DeactivePrev();
            ChangeState(State.menu);
        }

        private void ChangeState(State state)
        {
            currentState = state;
            ActiveNew(state);
        }

        private void DeactivePrev()
        {
            switch (currentState)
            {
                case State.preGameOptions:
                    preGameOptions.SetActive(false);
                    break;
                case State.options:
                    options.SetActive(false);
                    break;
                case State.autors:
                    autors.SetActive(false);
                    break;
            }
        }

        private void ActiveNew(State state)
        {
            switch (state)
            {
                case State.menu:
                    menu.SetActive(true);
                    break;
                case State.preGameOptions:
                    preGameOptions.SetActive(true);
                    break;
                case State.options:
                    options.SetActive(true);
                    break;
                case State.autors:
                    autors.SetActive(true);
                    break;
            }
        }

        private void Update()
        {
            if (!Input.GetKey(KeyCode.Escape)) return;
            
            if (currentState != State.menu)
            {
                ShowMenu();
            }
            else
            {
                Application.Quit();
            }
        }
    }
}