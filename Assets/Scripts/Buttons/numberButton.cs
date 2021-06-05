using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberButton : MonoBehaviour
{
    [SerializeField] Text buttonText;
    [SerializeField] Button button;
    [SerializeField] bool isRed;

    public int buttonNumber;
    public int totalBetOnThisButton;

    TotalBetTextDisplayer totalBetTextDisplayerReference;
    BalanceAmountTextDisplayer balanceAmountTextDisplayerReference;
    ButtonAnimationController buttonController;
    PlaceBetAnimation betAnimationController;

    //Bet types
    public bool inAStraightBet = false;
    public bool inAColumnOrDozenBet = false;    
    public bool inAColorEvenOddorlowHighBet = false;

    //Bet int to then pay
    public int straightBetValue = 0;
    public int ColumnOrDozenBetValue = 0;
    public int ColorOrEvenOddBetValue = 0;


    


    void Start()
    {
        buttonController = FindObjectOfType<ButtonAnimationController>();
        totalBetTextDisplayerReference = FindObjectOfType<TotalBetTextDisplayer>();
        balanceAmountTextDisplayerReference = FindObjectOfType<BalanceAmountTextDisplayer>();
        betAnimationController = FindObjectOfType<PlaceBetAnimation>();        
        
        button.onClick.AddListener(PlaceBet);
    }

    

    private void PlaceBet()
    {
        if (BetManager.IsMoneyEnough())
        {

            betAnimationController.PlaceChipInButton(transform.position.x, transform.position.y);

            BetManager.totalBet += BetManager.betValue;
            BetManager.totalMoney -= BetManager.betValue;

            inAStraightBet = true;
            straightBetValue += BetManager.betValue;

            totalBetOnThisButton += BetManager.betValue;
            
            //buttonText.text = BetManager.totalBet.ToString();

            UpdateTextDisplayers();
            
            Debug.Log("Total money bet on this spin: " + BetManager.totalBet);

            if (BetManager.betData.Contains(this))
            {
                
            }
            else
            {
                BetManager.betData.Add(this);
            }
                            
        }
        else
        {
            Debug.Log("Not enough money to place current chip");
        }                
    }

    private void UpdateTextDisplayers()
    {
        totalBetTextDisplayerReference.totalBetTextUI.text = BetManager.totalBet.ToString();
        balanceAmountTextDisplayerReference.balanceAmountTextUI.text = BetManager.totalMoney.ToString();
    }

    /*private bool IsMoneyEnough()
    {
        if(BetManager.totalMoney >= BetManager.betValue)
        {
            return true;
        }

        return false;
    }*/
}
