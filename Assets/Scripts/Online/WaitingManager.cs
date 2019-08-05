using System;
using UnityEngine;
using UnityEngine.UI;

namespace Online
{
    public class WaitingManager : MonoBehaviour
    {
        [SerializeField]
        private Text text;
        private void Start()
        {
            Network.WaitingEvent += OnWaiting;
        }

        private void OnWaiting()
        {
            text.text = "Waiting...";
        }
    }
}