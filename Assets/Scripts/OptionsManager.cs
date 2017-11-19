using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    public void changeWidthText(float width)
    {
        GetComponent<Text>().text = "Ширина поля: " + width;
        GameManager.getInstance().FieldWidth = Mathf.RoundToInt(width);
    }

    public void changeHeightText(float height)
    {
        GetComponent<Text>().text = "Высота поля: " + height;
        GameManager.getInstance().FieldHeight = Mathf.RoundToInt(height);
    }

    public void changeWinLine(float length)
    {
        GetComponent<Text>().text = "Длина линии: " + length;
        GameManager.getInstance().WinLine = Mathf.RoundToInt(length);
    }
} 
