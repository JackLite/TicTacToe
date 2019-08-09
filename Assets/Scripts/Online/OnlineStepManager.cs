using System;
using Game.Cell;
using Game.Field;
using UnityEngine;
using Core;

namespace Game.Online
{
    [RequireComponent(typeof(Network))]
    public class OnlineStepManager : MonoBehaviour
    {
        private static Network _network;

        public static string currentStepPlayerId;

        public static TextMoveController textMove;

        private void Start()
        {
            _network = GetComponent<Network>();
        }


        public static void MakeStep(Core.Step step)
        {
            ChangeWhoStep();

            _network.PlayerStep(step);
        }

        public static void ChangeWhoStep()
        {
            currentStepPlayerId = IsCurrentPlayerStep() ? _network.enemyNetworkId : _network.networkId;
            CellState state;
            PlayerType playerType;
            if (IsCurrentPlayerStep()) {
                playerType = GameManager.GetInstance().player.playerType;
            }
            else
            {
                var currentPlayerType = GameManager.GetInstance().player.playerType;
                playerType = currentPlayerType == PlayerType.cross ? PlayerType.zero : PlayerType.cross;
            }
            state = StateHelper.Convert(playerType);
            textMove.ChangeWhoMove(state);
        }

        public static bool IsCurrentPlayerStep()
        {
            return currentStepPlayerId == _network.networkId;
        }
    }
}