using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject resumeGameBtn;

        private void Start()
        {
            CheckResumeGame();
        }

        private void CheckResumeGame()
        {
            resumeGameBtn.SetActive(GameData.Instance.isExistGame);
        }
    }
}