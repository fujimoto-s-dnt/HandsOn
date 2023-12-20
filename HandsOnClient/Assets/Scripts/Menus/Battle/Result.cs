using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text resultText;

    public void Initialize(bool isWin)
    {
        if (isWin)
        {
            resultText.text = "勝ったど！";
        }
        else
        {
            resultText.text = "ボコられたど！";
        }
    }
}
