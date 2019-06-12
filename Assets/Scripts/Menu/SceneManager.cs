using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class SceneManager : MonoBehaviour
    {
        public PreGameOptionsManager preGameOptionsManager;

        public void StartGame()
        {
            GameManager.Instance.isResumeGame = false;
            preGameOptionsManager.SetParams();
            GameManager.getInstance().StartGame();
        }

        public void ResumeGame()
        {
            GameManager.Instance.isResumeGame = true;
            GameManager.Instance.StartGame();
        }
    }
}