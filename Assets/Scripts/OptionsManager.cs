using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

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
} 
