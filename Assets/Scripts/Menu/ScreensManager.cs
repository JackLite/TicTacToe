using UnityEngine;

namespace Menu
{
    public class ScreensManager : MonoBehaviour
    {
        public GameObject menu;
        public GameObject preGameOptions;
        public GameObject options;
        public GameObject authors;

        private enum State { Menu, PreGameOptions, Options, Authors };

        private State currentState = State.Menu;

        public void ShowOptions()
        {
            menu.SetActive(false);
            ChangeState(State.Options);
        }

        public void ShowPreGameOptions()
        {
            menu.SetActive(false);
            ChangeState(State.PreGameOptions);
        }

        public void ShowAutors()
        {
            menu.SetActive(false);
            ChangeState(State.Authors);
        }

        public void ShowMenu()
        {
            DeactivePrev();
            ChangeState(State.Menu);
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
                case State.PreGameOptions:
                    preGameOptions.SetActive(false);
                    break;
                case State.Options:
                    options.SetActive(false);
                    break;
                case State.Authors:
                    authors.SetActive(false);
                    break;
            }
        }

        private void ActiveNew(State state)
        {
            switch (state)
            {
                case State.Menu:
                    menu.SetActive(true);
                    break;
                case State.PreGameOptions:
                    preGameOptions.SetActive(true);
                    break;
                case State.Options:
                    options.SetActive(true);
                    break;
                case State.Authors:
                    authors.SetActive(true);
                    break;
            }
        }

        private void Update()
        {
            if (!Input.GetKey(KeyCode.Escape)) return;
            
            if (currentState != State.Menu)
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