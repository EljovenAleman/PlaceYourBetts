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

    Wheel wheel;

    void Start()
    {
        wheel = FindObjectOfType<Wheel>();
        spinButton.onClick.AddListener(StartBetCalculationTask);
    }

    private void StartBetCalculationTask()
    {
        wheel.Spin();
        
        GameManagerFactory.gameManager.ReturnNumber().AwaitInCoroutine(number => BetManager.CheckNumberOnList(number));
        
        wheel.StopSpinning(BetManager.winnerNumber);
        
    }
    
}
