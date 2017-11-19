using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] public GameObject MainMenu;
    [SerializeField] public GameObject Options;
    [SerializeField] public GameObject Autors;

    private void Awake()
    { 
        Debug.Log( Screen.dpi );
        MainMenu.GetComponent<VerticalLayoutGroup>().spacing = Screen.height * .05f;
    }
    public void ShowOptions()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void ReturnFromOptions()
    {
        Options.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void ReturnFromAutors()
    {
        Autors.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void StartGame()
    {
        GameManager.getInstance().StartGame();
    }

}
