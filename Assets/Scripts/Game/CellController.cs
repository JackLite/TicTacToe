using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TrueGames;

public class CellController : MonoBehaviour
{
    private AI AI;
    private bool choosen = false;

    public const string childName = "inner";

    public int hor_number { get; set; }
    public int vert_number { get; set; }
    public SceneManager sceneManager
    {
        get; set;
    }
    public FieldManager fieldManager
    {
        get; set;
    }
    public enum State
    {
        empty,
        cross,
        zero
    }
    public Color choosenColor;
    public bool Choosen
    {
        get
        {
            return choosen;
        }
        set
        {
            choosen = value;
        }
    }


    public State currentState = State.empty;

    public void Start()
    {
        AI = sceneManager.AI.GetComponent<AI>();
    }

    public void clickHandler(BaseEventData eventData)
    {
        if (currentState != State.empty)
        {
            return;
        }
        sceneManager.GetComponent<TextMoveController>().changeWhoMove(fieldManager.lastState);
        if (fieldManager.lastState == State.zero)
        {
            setState(State.cross);
        }
        else
        {
            setState(State.zero);
        }

        // пока ИИ не делаем
        //AI.nextMove();
    }

    public void setState(State state)
    {
        Image innerImage = transform.Find(childName).GetComponent<Image>();
        innerImage.color = new Color(0, 0, 0, 255);
        innerImage.sprite = sceneManager.getSprite(state);
        currentState = state;
        fieldManager.lastState = state;
        GameData.Instance.lastState = state;
        fieldManager.updateFieldState(hor_number, vert_number, this);
        bool isEndGame = fieldManager.gameObject.GetComponent<WinnerChecker>().checkWinner(hor_number, vert_number, fieldManager.fieldState);
        if (isEndGame)
        {
            GameData.Instance.isExistGame = false;
            GameManager.Instance.GetComponent<DataManager>().SaveGameData();
        }
    }
}
