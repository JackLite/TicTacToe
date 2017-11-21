using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTouch : MonoBehaviour
{
    private RectTransform fieldTransform;

    public float speedMove = .1f;

    [SerializeField] GameObject GameField;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Vector2 curPos = Input.GetTouch(0).position;
            Vector2 prevPos = curPos - Input.GetTouch(0).deltaPosition;
            float horDelta = curPos.x - prevPos.x;
            float vertDelta = curPos.y - prevPos.y;
            float newHorPos = GameField.GetComponent<RectTransform>().localPosition.x + horDelta * speedMove * Time.deltaTime;
            float newVertPos = GameField.GetComponent<RectTransform>().localPosition.y + vertDelta * speedMove * Time.deltaTime;
            GameField.GetComponent<RectTransform>().localPosition = new Vector3(newHorPos, newVertPos);
        }
    }
}
