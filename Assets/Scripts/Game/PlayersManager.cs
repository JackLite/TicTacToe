using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour {
    [SerializeField] GameObject playerPrefab;
    private void Start()
    {
        GameObject PlayerOne = GameObject.Instantiate<GameObject>(playerPrefab);
        PlayerController playerOneController = PlayerOne.GetComponent<PlayerController>();

        GameObject PlayerTwo = GameObject.Instantiate<GameObject>(playerPrefab);
        PlayerController playerTwoController = PlayerTwo.GetComponent<PlayerController>();
    }

}
