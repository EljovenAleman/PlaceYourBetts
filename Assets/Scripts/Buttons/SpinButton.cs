using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpinButton : MonoBehaviour
{
    [SerializeField] Button spinButton;
    public int ballNumber;

    void Start()
    {
        spinButton.onClick.AddListener(StartBetCalculationTask);
    }

    private void StartBetCalculationTask()
    {
        Debug.Log("Boton presionado");
        GameManagerFactory.gameManager.ReturnNumber().AwaitInCoroutine(number => BetManager.CheckNumberOnList(number));        
    }
    
}
