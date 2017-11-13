using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrueGames {
    public class SceneManager : MonoBehaviour
    {
        [SerializeField]
        public Sprite cell;

        [SerializeField]
        public Sprite cross;

        [SerializeField]
        public Sprite zero;

        [SerializeField]
        public GameObject AI;

        public Sprite getCell()
        {
            return cell;
        }

        public Sprite getSprite(CellController.State state)
        {
            if (state == CellController.State.cross)
            {
                return cross;
            } else
            {
                return zero;
            }
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.getInstance().ExitToMenu();
            }
        }
    }
}