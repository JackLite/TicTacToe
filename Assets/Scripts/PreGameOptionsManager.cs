using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreGameOptionsManager : MonoBehaviour {

    [SerializeField] GameObject SliderWidth;
    [SerializeField] GameObject SliderHeight;
    [SerializeField] GameObject SliderWinScore;

    public void changeWidthText(float width)
    {
        GetComponent<Text>().text = "Ширина поля: " + width;
    }

    public void changeHeightText(float height)
    {
        GetComponent<Text>().text = "Высота поля: " + height;
    }

    public void changeWinLine(float length)
    {
        GetComponent<Text>().text = "Длина линии: " + length;
    }

    public void setParams()
    {
        GameManager.getInstance().FieldWidth = Mathf.RoundToInt(SliderWidth.GetComponent<Slider>().value);
        GameManager.getInstance().FieldHeight = Mathf.RoundToInt(SliderHeight.GetComponent<Slider>().value);
        GameManager.getInstance().WinLine = Mathf.RoundToInt(SliderWinScore.GetComponent<Slider>().value);
    }
} 
