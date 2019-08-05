using System;
using Game.Cell;
using Game.Field;
using SocketIO;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Online
{
    [RequireComponent(typeof(SocketIOComponent))]
    public class Network : MonoBehaviour
    {
        private static SocketIOComponent _socket;
        public string networkId;
        public string enemyNetworkId;

        public delegate void OnNetworkHandler();

        public static event OnNetworkHandler WaitingEvent;
        public static event OnNetworkHandler EnemyFindEvent;

        private void Awake()
        {
            _socket = GetComponent<SocketIOComponent>();
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _socket.On("successful connected", OnSuccessfulConnected);
            _socket.On("waiting", e => WaitingEvent?.Invoke());
            _socket.On("enemy find", OnEnemyFind);
            _socket.On("first player", OnFirstPlayer);
            _socket.On("enemy step", OnEnemyStep);
        }

        private void OnEnemyStep(SocketIOEvent e)
        {
            var position = new CellPosition((int) e.data["position"]["x"].n, (int) e.data["position"]["y"].n);
            var state = (CellState) e.data["state"].n;
            FieldManager.Find(position)?.SetState(state);
            OnlineStepManager.ChangeWhoStep();
        }

        private void OnFirstPlayer(SocketIOEvent e)
        {
            OnlineStepManager.currentStepPlayerId = e.data["id"].str;
        }

        private void OnEnemyFind(SocketIOEvent e)
        {
            EnemyFindEvent?.Invoke();
            enemyNetworkId = e.data["id"].str;
        }
        private void OnSuccessfulConnected(SocketIOEvent e)
        {
            networkId = e.data["id"].str;
        }

        public void Connect()
        {
            _socket.Connect();
        }

        public void PlayerStep(CellPosition position, CellState state)
        {
            var json = JSONObject.Create(JSONObject.Type.OBJECT);
            json.AddField("id", networkId);
            json.AddField("enemyId", enemyNetworkId);
            var jsonPosition = JSONObject.Create(JSONObject.Type.OBJECT);
            jsonPosition.AddField("x", position.X);
            jsonPosition.AddField("y", position.Y);
            json.AddField("position", jsonPosition);
            json.AddField("state", (int) state);
            _socket.Emit("player step", json);
        }
    }
}