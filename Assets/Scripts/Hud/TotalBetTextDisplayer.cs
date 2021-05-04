using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TotalBetTextDisplayer : MonoBehaviour
{
    public Text totalBetTextUI;

    void Start()
    {
        totalBetTextUI = GetComponent<Text>();
        totalBetTextUI.text = "0";
    }
}
