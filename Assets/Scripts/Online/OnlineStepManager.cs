using System;
using Game.Cell;
using Game.Field;
using UnityEngine;

namespace Online
{
    [RequireComponent(typeof(Network))]
    public class OnlineStepManager : MonoBehaviour
    {
        private static Network _network;
        public static string currentStepPlayerId;

        private void Start()
        {
            _network = GetComponent<Network>();
        }


        public static void MakeStep(CellPosition position, CellState state)
        {
            ChangeWhoStep();

            _network.PlayerStep(position, state);
        }

        public static void ChangeWhoStep()
        {
            currentStepPlayerId = IsCurrentPlayerStep() ? _network.enemyNetworkId : _network.networkId;
        }

        public static bool IsCurrentPlayerStep()
        {
            return currentStepPlayerId == _network.networkId;
        }
        
    }
}