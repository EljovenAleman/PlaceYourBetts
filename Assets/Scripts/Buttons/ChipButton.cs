using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChipButton : MonoBehaviour
{

    [SerializeField] Button chipButton;
    [SerializeField] int chipValue;
    Image chipSprite;
    ButtonAnimationController buttonAnimationController;

    void Start()
    {
        chipSprite = GetComponent<Image>();
        buttonAnimationController = FindObjectOfType<ButtonAnimationController>();
        chipButton.onClick.AddListener(ChangeBetValue);
        chipButton.onClick.AddListener(ChangeAnimation);
    }

    private void ChangeBetValue()
    {
        BetManager.betValue = chipValue;
    }

    private void ChangeAnimation()
    {
        buttonAnimationController.ActivateButtonAnimation(chipSprite);
    }
}
