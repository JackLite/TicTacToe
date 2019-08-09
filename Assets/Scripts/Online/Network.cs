using System;
using Game.Cell;
using Game.Field;
using SocketIO;
using UnityEngine;
using Core;

namespace Game.Online
{
    [RequireComponent(typeof(SocketIOComponent))]
    public class Network : MonoBehaviour
    {
        private static SocketIOComponent _socket;

        public string networkId;
        public string enemyNetworkId;
        public static string enemyNickName;

        public static event Action WaitingEvent;
        public static event Action EnemyFindEvent;

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
            var state = GameManager.GetInstance().player.playerType == PlayerType.cross ? CellState.Zero : CellState.Cross;
            FieldManager.Find(position)?.SetState(state);
            OnlineStepManager.ChangeWhoStep();
        }

        private void OnFirstPlayer(SocketIOEvent e)
        {
            string firstPlayerNetworkId = e.data["id"].str;
            OnlineStepManager.currentStepPlayerId = firstPlayerNetworkId;
            GameManager gameManager = GameManager.GetInstance();
            if (firstPlayerNetworkId == gameManager.player.networkId)
            {
                gameManager.player.playerType = PlayerType.cross;
            }
            else
            {
                gameManager.player.playerType = PlayerType.zero;
            }
        }

        private void OnEnemyFind(SocketIOEvent e)
        {
            EnemyFindEvent?.Invoke();
            enemyNetworkId = e.data["id"].str;
            enemyNickName = e.data["nickname"].str;
            Debug.Log(enemyNickName);
        }
        private void OnSuccessfulConnected(SocketIOEvent e)
        {
            networkId = e.data["id"].str;
            GameManager.GetInstance().player.networkId = e.data["id"].str;
            var json = JSONObject.Create(JSONObject.Type.OBJECT);
            json.AddField("nickname", GameManager.GetInstance().player.name);
            Debug.Log(GameManager.GetInstance().player.name);
            _socket.Emit("player settings", json);
        }

        public void Connect()
        {
            _socket.Connect();
        }

        public void PlayerStep(Step step)
        {
            var json = JSONObject.Create(JSONObject.Type.OBJECT);
            json.AddField("id", networkId);
            json.AddField("enemyId", enemyNetworkId);
            var jsonPosition = JSONObject.Create(JSONObject.Type.OBJECT);
            jsonPosition.AddField("x", step.cellPosition.X);
            jsonPosition.AddField("y", step.cellPosition.Y);
            json.AddField("position", jsonPosition);
            _socket.Emit("player step", json);
        }

        public void EndGame(Player winner)
        {
            var json = JSONObject.Create(JSONObject.Type.OBJECT);
            json.AddField("winnerId", winner.networkId);
            json.AddField("winnerName", winner.name);
            _socket.Emit("end game", json);
        }

        public static void Disconnect()
        {
            _socket?.Close();
        }
    }
}