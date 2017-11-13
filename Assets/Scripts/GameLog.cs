using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLog : MonoBehaviour {
     
    GameManager gm;

    GameObject log;

    void Start()
    {
        gm = GetComponent<GameManager>();
    }
	
    public void ShowLog(object Message)
    {
        log.GetComponent<Text>().text = Message.ToString();
    } 
}
