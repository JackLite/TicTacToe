using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    private OptionsManager optionsManager;

    [SerializeField] public GameObject MainMenu;
    [SerializeField] public GameObject Options;
    [SerializeField] public GameObject Autors;
    [SerializeField] public GameObject OptionsBackBtn;
    [SerializeField] public GameObject OptionsStartBtn;

    private void Awake()
    { 
        MainMenu.GetComponent<VerticalLayoutGroup>().spacing = Screen.height * .05f;
        optionsManager = GetComponent<OptionsManager>();
    }
    public void ShowOptions(bool isStartGame)
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
        if(isStartGame)
        {
            OptionsBackBtn.SetActive(false);
            OptionsStartBtn.SetActive(true);
        }
        else
        {
            OptionsBackBtn.SetActive(true);
            OptionsStartBtn.SetActive(false);
        }
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
        optionsManager.setParams();
        GameManager.getInstance().StartGame();
    }

}
