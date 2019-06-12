using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class PreGameOptionsManager : MonoBehaviour
    {
        private Slider sliderWidth;
        private Slider sliderHeight;
        private Slider sliderWinScore;

        private Text sliderWidthText;
        private Text sliderHeightText;
        private Text sliderWinScoreText;

        private void Start()
        {
            InitFields();

            SetSavedValue();

            ChangeWidthText(GameData.Instance.fieldWidth);
            ChangeHeightText(GameData.Instance.fieldHeight);
            ChangeWinLine(GameData.Instance.winLine);
        }

        private void SetSavedValue()
        {
            sliderWidth.value = GameData.Instance.fieldWidth;
            sliderHeight.value = GameData.Instance.fieldHeight;
            sliderWinScore.value = GameData.Instance.winLine;
        }

        private void InitFields()
        {
            sliderWidth = transform.Find("OptionsBlock/FieldWidth/SliderWidth").GetComponent<Slider>();
            sliderHeight = transform.Find("OptionsBlock/FieldHeight/SliderHeight").GetComponent<Slider>();
            sliderWinScore = transform.Find("OptionsBlock/WinLine/SliderWinScore").GetComponent<Slider>();

            sliderWidthText = transform.Find("OptionsBlock/FieldWidth/TextWidth").GetComponent<Text>();
            sliderHeightText = transform.Find("OptionsBlock/FieldHeight/TextHeight").GetComponent<Text>();
            sliderWinScoreText = transform.Find("OptionsBlock/WinLine/TextWinLine").GetComponent<Text>();
        }

        private void ChangeWidthText(float width)
        {
            sliderWidthText.text = "Ширина поля: " + width;
        }

        private void ChangeHeightText(float height)
        {
            sliderHeightText.text = "Высота поля: " + height;
        }

        private void ChangeWinLine(float length)
        {
            sliderWinScoreText.text = "Длина линии: " + length;
        }

        public void SetParams()
        {
            GameData.Instance.fieldWidth = Mathf.RoundToInt(sliderWidth.value);
            GameData.Instance.fieldHeight = Mathf.RoundToInt(sliderHeight.value);
            GameData.Instance.winLine = Mathf.RoundToInt(sliderWinScore.value);
            DataManager.SaveGameData();
        }
    }
}