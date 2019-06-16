using System.Collections;
using System.Collections.Generic;
using Game.Field;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TrueGames;

public class CellController : MonoBehaviour
{
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


    public CellState currentState = CellState.Empty;

    public void clickHandler(BaseEventData eventData)
    {
        if (currentState != CellState.Empty)
        {
            return;
        }
        sceneManager.GetComponent<TextMoveController>().changeWhoMove(fieldManager.LastState);
        if (fieldManager.LastState == CellState.Zero)
        {
            setState(CellState.Cross);
        }
        else
        {
            setState(CellState.Zero);
        }
    }

    public void setState(CellState state)
    {
        Image innerImage = transform.Find(childName).GetComponent<Image>();
        innerImage.color = new Color(0, 0, 0, 255);
        innerImage.sprite = sceneManager.getSprite(state);
        currentState = state;
        fieldManager.LastState = state;
        GameData.Instance.lastState = state;
        fieldManager.UpdateFieldState(hor_number, vert_number, state);
        bool isEndGame = fieldManager.gameObject.GetComponent<WinnerChecker>().checkWinner(hor_number, vert_number, fieldManager.fieldState);
        if (isEndGame)
        {
            GameData.Instance.isExistGame = false;
            DataManager.SaveGameData();
        }
    }

    private void Start()
    {
        var eventTrigger = GetComponent<EventTrigger>();
        var eventEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerClick};
        eventEntry.callback.AddListener(clickHandler);
        eventTrigger.triggers.Add(eventEntry);
    }
}
