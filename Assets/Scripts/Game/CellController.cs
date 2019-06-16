using Game.Field;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TrueGames;

public class CellController : MonoBehaviour
{
    public const string ChildName = "inner";
    
    [SerializeField]
    private Image innerImage;

    public int HorNumber { get; set; }
    public int VertNumber { get; set; }
    public SceneManager SceneManager
    {
        get; set;
    }
    public FieldManager FieldManager
    {
        get; set;
    }

    public CellState currentState = CellState.Empty;

    private void Start()
    {
        InitClickHandler();
    }

    private void InitClickHandler()
    {
        var eventTrigger = GetComponent<EventTrigger>();
        var eventEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerClick};
        eventEntry.callback.AddListener(clickHandler);
        eventTrigger.triggers.Add(eventEntry);
    }

    public void clickHandler(BaseEventData eventData)
    {
        if (currentState != CellState.Empty)
        {
            return;
        }

        var state = FieldManager.CurrentState == CellState.Cross ? CellState.Cross : CellState.Zero;
        SetState(state);
        FieldManager.SwitchState(state);
    }

    public void SetState(CellState state)
    {
        innerImage.color = new Color(0, 0, 0, 255);
        innerImage.sprite = SceneManager.getSprite(state);
        currentState = state;
        FieldManager.CurrentState = state;
        GameData.Instance.lastState = state;
        FieldManager.UpdateFieldState(HorNumber, VertNumber, state);
        bool isEndGame = FieldManager.gameObject.GetComponent<WinnerChecker>().checkWinner(HorNumber, VertNumber, FieldManager.fieldState);
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
