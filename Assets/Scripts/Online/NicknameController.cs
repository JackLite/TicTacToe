using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NicknameController : MonoBehaviour
{
    public InputField inputNickName;

    void Start()
    {
        inputNickName.text = DataManager.GetGameData().onlineNickName;
    }
}
