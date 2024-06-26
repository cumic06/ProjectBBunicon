using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameChecker : MonoBehaviour
{
    private float deltaTime;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        GUIStyle style = new();

        Rect rect = new Rect(30, 30, Screen.width, Screen.height);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = 25;
        style.normal.textColor = Color.green;

        float ms = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = $"Fps:{fps:00.00}/ms:{ms:0.0}";

        GUI.Label(rect, text, style);
    }
}
