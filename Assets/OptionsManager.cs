using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    [SerializeField] GameObject PlayerOneNickField;
    [SerializeField] GameObject PlayerTwoNickField;

    public void setParams()
    {
        PlayersManager playersManager = GameManager.getInstance().gameObject.GetComponent<PlayersManager>();
        playersManager.playerOneName = PlayerOneNickField.GetComponent<InputField>().text;
        playersManager.playerTwoName = PlayerTwoNickField.GetComponent<InputField>().text;
    }
}
