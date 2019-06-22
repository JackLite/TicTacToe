using System;

[Serializable]
public struct PlayersName
{
    public string first;
    public string second;

    public PlayersName(string first, string second)
    {
        this.first = first;
        this.second = second;
    }
}