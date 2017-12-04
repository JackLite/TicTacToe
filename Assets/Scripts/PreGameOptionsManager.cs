using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreGameOptionsManager : MonoBehaviour {

    [SerializeField] GameObject SliderWidth;
    [SerializeField] GameObject SliderHeight;
    [SerializeField] GameObject SliderWinScore;

    [SerializeField] GameObject SliderWidthText;
    [SerializeField] GameObject SliderHeightText;
    [SerializeField] GameObject SliderWinScoreText;

    private void Start()
    {
        SliderWidth.GetComponent<Slider>().value = GameData.Instance.fieldWidth;
        SliderHeight.GetComponent<Slider>().value = GameData.Instance.fieldHeight;
        SliderWinScore.GetComponent<Slider>().value = GameData.Instance.winLine;
    }

    public void changeWidthText(float width)
    {
        SliderWidthText.GetComponent<Text>().text = "Ширина поля: " + width;
    }

    public void changeHeightText(float height)
    {
        SliderHeightText.GetComponent<Text>().text = "Высота поля: " + height;
    }

    public void changeWinLine(float length)
    {
        SliderWinScoreText.GetComponent<Text>().text = "Длина линии: " + length;
    }

    public void setParams()
    {
        GameData.Instance.fieldWidth = Mathf.RoundToInt(SliderWidth.GetComponent<Slider>().value);
        GameData.Instance.fieldHeight = Mathf.RoundToInt(SliderHeight.GetComponent<Slider>().value);
        GameData.Instance.winLine = Mathf.RoundToInt(SliderWinScore.GetComponent<Slider>().value);
        GameManager.Instance.GetComponent<DataManager>().SaveGameData();
    }
} 
