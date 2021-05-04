using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationController : MonoBehaviour
{

    [SerializeField] Image chip1;

    [SerializeField] Image chip5;

    [SerializeField] Image chip50;

    [SerializeField] Image chip100;

    [SerializeField] Image chip500;

    [SerializeField] List<Image> imagesList;

    public Image SelectedChipImage;



    //private List<Image> attenuateThisimages;

    private void Start()
    {        
        imagesList.Add(chip1);
        imagesList.Add(chip5);
        imagesList.Add(chip50);
        imagesList.Add(chip100);
        imagesList.Add(chip500);
    }


    public void ActivateButtonAnimation(Image buttonPressed)
    {
        foreach(Image image in imagesList)
        {
            if(buttonPressed == image)
            {                
                image.color = new Color32(255, 255, 255, 255);
                SelectedChipImage.sprite = image.sprite;
                foreach(Image imageToAttenuate in imagesList)
                {
                    if(imageToAttenuate != image)
                    {
                        imageToAttenuate.color = new Color32(140, 140, 140, 255);
                    }
                }
            }
        }
    }

    
    
}
