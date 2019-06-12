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
            if (currentState == State.preGameOptions)
            {
                preGameOptions.SetActive(false);
            }
            if (currentState == State.options)
            {
                options.SetActive(false);
            }
            if (currentState == State.autors)
            {
                autors.SetActive(false);
            }
        }

        private void ActiveNew(State state)
        {
            if (state == State.menu)
            {
                menu.SetActive(true);
            }
            if (state == State.preGameOptions)
            {
                preGameOptions.SetActive(true);
            }
            if (state == State.options)
            {
                options.SetActive(true);
            }
            if (state == State.autors)
            {
                autors.SetActive(true);
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
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
}