using System;
using UnityEngine.Serialization;

[Serializable]
public struct FieldSettings
{
    public int width;
    public int height;
    public int winLine;

    public FieldSettings(int width = 3, int height = 3, int winLine = 3)
    {
        this.width = width;
        this.height = height;
        this.winLine = winLine;
    }
}