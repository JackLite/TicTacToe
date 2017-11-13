using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour {
    [SerializeField] GameObject playerPrefab;
    private void Awake()
    {
        GameObject PlayerOne = GameObject.Instantiate<GameObject>(playerPrefab);
        PlayerController playerOneController = PlayerOne.GetComponent<PlayerController>();
        playerOneController.side = GameManager.Side.cross;

        GameObject PlayerTwo = GameObject.Instantiate<GameObject>(playerPrefab);
        PlayerController playerTwoController = PlayerTwo.GetComponent<PlayerController>();
        playerTwoController.side = GameManager.Side.zero;
    }

}
