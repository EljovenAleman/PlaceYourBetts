using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceBetAnimation : MonoBehaviour
{
    ButtonAnimationController buttonController;
    private GameObject chip;

    
    public Image selectedChipImage;

    void Start()
    {
        
        buttonController = FindObjectOfType<ButtonAnimationController>();
        selectedChipImage = buttonController.SelectedChipImage;
        
    }

    public void PlaceChipInButton(float x, float y)
    {
        chip = GameObject.FindGameObjectWithTag("ChipObject");
        chip.tag = "Untagged";
        var renderer = chip.GetComponent<SpriteRenderer>();
        renderer.sprite = selectedChipImage.sprite;
        
        
        

        

        chip.transform.position = new Vector2(x, y);

        
    }
    
}
