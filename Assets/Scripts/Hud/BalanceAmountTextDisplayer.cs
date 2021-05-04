using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BalanceAmountTextDisplayer : MonoBehaviour
{
    public Text balanceAmountTextUI;

    void Start()
    {
        balanceAmountTextUI = GetComponent<Text>();
        balanceAmountTextUI.text = BetManager.totalMoney.ToString();
    }
}
