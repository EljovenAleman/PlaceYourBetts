using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberGroupButton : MonoBehaviour
{
    [SerializeField] Button button;
    public int totalBetOnThisButton;

    TotalBetTextDisplayer totalBetTextDisplayerReference;
    BalanceAmountTextDisplayer balanceAmountTextDisplayerReference;
    PlaceBetAnimation betAnimationController;


    [SerializeField] numberButton button1 = null;
    [SerializeField] numberButton button2 = null;
    [SerializeField] numberButton button3 = null;
    [SerializeField] numberButton button4 = null;
    [SerializeField] numberButton button5 = null;
    [SerializeField] numberButton button6 = null;
    [SerializeField] numberButton button7 = null;
    [SerializeField] numberButton button8 = null;
    [SerializeField] numberButton button9 = null;
    [SerializeField] numberButton button10 = null;
    [SerializeField] numberButton button11 = null;
    [SerializeField] numberButton button12 = null;
    [SerializeField] numberButton button13 = null;
    [SerializeField] numberButton button14 = null;
    [SerializeField] numberButton button15 = null;
    [SerializeField] numberButton button16 = null;
    [SerializeField] numberButton button17 = null;
    [SerializeField] numberButton button18 = null;

    private List<numberButton> groupButtons;


    void Start()
    {
        totalBetTextDisplayerReference = FindObjectOfType<TotalBetTextDisplayer>();
        balanceAmountTextDisplayerReference = FindObjectOfType<BalanceAmountTextDisplayer>();
        betAnimationController = FindObjectOfType<PlaceBetAnimation>();
        groupButtons = new List<numberButton>();
        AddAllButtonsToList();
        button.onClick.AddListener(PlaceBetOnEachButton);        
    }

    private void PlaceBetOnEachButton()
    {
        if (BetManager.IsMoneyEnough())
        {

            betAnimationController.PlaceChipInButton(transform.position.x, transform.position.y);

            BetManager.totalBet += BetManager.betValue;
            BetManager.totalMoney -= BetManager.betValue;
            totalBetOnThisButton += BetManager.betValue;

            //buttonText.text = BetManager.totalBet.ToString();

            UpdateTextDisplayers();

            Debug.Log("Total money bet on this spin: " + BetManager.totalBet);


            foreach (numberButton button in groupButtons)
            {
                if (BetManager.betData.Contains(button))
                {

                }
                else
                {
                    BetManager.betData.Add(button);
                }
            }


        }
        else
        {
            Debug.Log("Not enough money to place current chip");
        }
    }

    private void PlaceBet()
    {
        if (BetManager.IsMoneyEnough())
        {
            BetManager.totalBet += BetManager.betValue;
            BetManager.totalMoney -= BetManager.betValue;
            totalBetOnThisButton += BetManager.betValue;

            //buttonText.text = BetManager.totalBet.ToString();

            UpdateTextDisplayers();

            Debug.Log("Total money bet on this spin: " + BetManager.totalBet);


            foreach(numberButton button in groupButtons)
            {
                if (BetManager.betData.Contains(button))
                {

                }
                else
                {
                    BetManager.betData.Add(button);
                }
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

    private void AddAllButtonsToList()
    {
        groupButtons.Add(button1);
        groupButtons.Add(button2);
        groupButtons.Add(button3);
        groupButtons.Add(button4);
        groupButtons.Add(button5);
        groupButtons.Add(button6);
        groupButtons.Add(button7);
        groupButtons.Add(button8);
        groupButtons.Add(button9);
        groupButtons.Add(button10);
        groupButtons.Add(button11);
        groupButtons.Add(button12);
        groupButtons.Add(button13);
        groupButtons.Add(button14);
        groupButtons.Add(button15);
        groupButtons.Add(button16);
        groupButtons.Add(button17);
        groupButtons.Add(button18);        
    }
}
