using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnlineOptionsScreenController : MonoBehaviour
{
    public Button startGameBtn;

    private static Button _startGameBtn;

    private void Awake()
    {
        _startGameBtn = startGameBtn;        
    }

    public static void ResetScreenStatic()
    {
        _startGameBtn.transform.GetComponentInChildren<Text>().text = "Играть";
    }

    public void ResetScreen()
    {
        ResetScreenStatic();
    }
}
