using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] public GameObject MainMenu;
    [SerializeField] public GameObject Options;
    [SerializeField] public GameObject Autors;


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
