using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    [SerializeField] GameObject PlayerOneNickField;
    [SerializeField] GameObject PlayerTwoNickField;

    private void Start()
    {
        string[] playersName = GameData.Instance.playersName;

        if (playersName[0] != null && playersName[1] != null)
        {
            PlayerOneNickField.GetComponent<InputField>().text = playersName[0];
            PlayerTwoNickField.GetComponent<InputField>().text = playersName[1];
        }
    }

    public void setParams()
    {
        PlayersManager playersManager = GameManager.getInstance().gameObject.GetComponent<PlayersManager>();
        playersManager.playerOneName = PlayerOneNickField.GetComponent<InputField>().text;
        playersManager.playerTwoName = PlayerTwoNickField.GetComponent<InputField>().text;

        GameData.Instance.playersName[0] = playersManager.playerOneName;
        GameData.Instance.playersName[1] = playersManager.playerTwoName;
        GameManager.Instance.gameObject.GetComponent<DataManager>().SaveGameData();
    }
}
