using Game.Field;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TrueGames;
using TrueGames.Cell;
using UnityEngine.Serialization;

public class CellController : MonoBehaviour
{
    [SerializeField]
    private Image innerImage;
    
    private FieldManager fieldManager;
    private FieldSettings fieldSettings;
    private SceneManager sceneManager;
    private CellPosition position;
    public CellState currentState = CellState.Empty;

    public void SetPosition(CellPosition pos)
    {
        position = pos;
    }
    
    public void SetSceneManager(SceneManager manager)
    {
        sceneManager = manager;
    }

    public void SetFieldManager(FieldManager manager)
    {
        fieldManager = manager;
    }
    
    private void Start()
    {
        InitClickHandler();
    }

    private void InitClickHandler()
    {
        var eventTrigger = GetComponent<EventTrigger>();
        var eventEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerClick};
        eventEntry.callback.AddListener(ClickHandler);
        eventTrigger.triggers.Add(eventEntry);
    }

    private void ClickHandler(BaseEventData eventData)
    {
        if (currentState != CellState.Empty)
        {
            return;
        }

        var state = fieldManager.CurrentState == CellState.Cross ? CellState.Cross : CellState.Zero;
        SetState(state);
        fieldManager.SwitchState(state);
    }

    private void SetState(CellState state)
    {
        innerImage.color = new Color(0, 0, 0, 255);
        innerImage.sprite = sceneManager.getSprite(state);
        currentState = state;
        fieldManager.CurrentState = state;
        GameData.Instance.lastState = state;
        fieldManager.UpdateFieldState(position.X, position.Y, state);
        bool isEndGame = fieldManager.gameObject.GetComponent<WinnerChecker>().checkWinner(position.X, position.Y, fieldManager.fieldState);
        if (isEndGame)
        {
            GameData.Instance.isExistGame = false;
            DataManager.SaveGameData();
        }
    }

    public Image GetInnerImage()
    {
        return innerImage;
    }
}
