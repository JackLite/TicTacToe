﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomTouch : MonoBehaviour
{
    private float currentZoom = 1f;
    private float horSize;
    private float vertSize;

    public float speedZoom = .5f;
    [SerializeField] public GameObject GameField;

    private void Start()
    {
        horSize = GameField.GetComponent<FieldManger>().cellSize * GameManager.getInstance().FieldWidth;
        vertSize = GameField.GetComponent<FieldManger>().cellSize * GameManager.getInstance().FieldHeight;
    }
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 prevZeroPosition = touchZero.position - touchZero.deltaPosition;
            Vector2 prevOnePosition = touchOne.position - touchOne.deltaPosition;
            float prevDist = (prevZeroPosition - prevOnePosition).magnitude;
            float dist = (touchZero.position - touchOne.position).magnitude;
            currentZoom = currentZoom + (dist - prevDist)/dist * speedZoom;
            currentZoom = Mathf.Clamp(currentZoom, .1f, 3f);
            GameField.GetComponent<RectTransform>().localScale = new Vector3(currentZoom, currentZoom, 1);
        }
    }
}
