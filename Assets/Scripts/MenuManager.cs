using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    private PreGameOptionsManager preGameOptionsManager;
    private OptionsManager optionsManager;
    private State state = State.main;
    private enum State
    {
        main,
        pregame,
        options
    }

    [SerializeField] public GameObject MainMenu;
    [SerializeField] public GameObject PreGameOptions;
    [SerializeField] public GameObject Options;
    [SerializeField] public GameObject Autors;
    [SerializeField] public GameObject OptionsBackBtn;
    [SerializeField] public GameObject OptionsStartBtn;

    private void Awake()
    { 
        MainMenu.GetComponent<VerticalLayoutGroup>().spacing = Screen.height * .05f;
        preGameOptionsManager = GetComponent<PreGameOptionsManager>();
        optionsManager = GetComponent<OptionsManager>();
    }
    public void ShowOptions(bool isStartGame)
    {
        MainMenu.SetActive(false);
        if(isStartGame)
        {
            state = State.pregame;
            PreGameOptions.SetActive(true);
        }
        else
        {
            state = State.options;
            Options.SetActive(true);
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
        preGameOptionsManager.setParams();
        optionsManager.setParams();
        GameManager.getInstance().StartGame();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(state == State.options)
            {
                Options.SetActive(false);
                MainMenu.SetActive(true);
            }
            else if(state == State.pregame)
            {
                PreGameOptions.SetActive(false);
                MainMenu.SetActive(true);
            }
        }
    }
}
