using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] Rigidbody2D wheel;
    private bool shouldTheWheelSpin = false;
    private float rotationSpeed;

    [SerializeField] WheelNumber wheelNumber0;
    [SerializeField] WheelNumber wheelNumber1;
    [SerializeField] WheelNumber wheelNumber2;
    [SerializeField] WheelNumber wheelNumber3;
    [SerializeField] WheelNumber wheelNumber4;
    [SerializeField] WheelNumber wheelNumber5;
    [SerializeField] WheelNumber wheelNumber6;
    [SerializeField] WheelNumber wheelNumber7;
    [SerializeField] WheelNumber wheelNumber8;
    [SerializeField] WheelNumber wheelNumber9;
    [SerializeField] WheelNumber wheelNumber10;
    [SerializeField] WheelNumber wheelNumber11;
    [SerializeField] WheelNumber wheelNumber12;
    [SerializeField] WheelNumber wheelNumber13;
    [SerializeField] WheelNumber wheelNumber14;
    [SerializeField] WheelNumber wheelNumber15;
    [SerializeField] WheelNumber wheelNumber16;
    [SerializeField] WheelNumber wheelNumber17;
    [SerializeField] WheelNumber wheelNumber18;
    [SerializeField] WheelNumber wheelNumber19;
    [SerializeField] WheelNumber wheelNumber20;
    [SerializeField] WheelNumber wheelNumber21;
    [SerializeField] WheelNumber wheelNumber22;
    [SerializeField] WheelNumber wheelNumber23;
    [SerializeField] WheelNumber wheelNumber24;
    [SerializeField] WheelNumber wheelNumber25;
    [SerializeField] WheelNumber wheelNumber26;
    [SerializeField] WheelNumber wheelNumber27;
    [SerializeField] WheelNumber wheelNumber28;
    [SerializeField] WheelNumber wheelNumber29;
    [SerializeField] WheelNumber wheelNumber30;
    [SerializeField] WheelNumber wheelNumber31;
    [SerializeField] WheelNumber wheelNumber32;
    [SerializeField] WheelNumber wheelNumber33;
    [SerializeField] WheelNumber wheelNumber34;
    [SerializeField] WheelNumber wheelNumber35;
    [SerializeField] WheelNumber wheelNumber36;
    [SerializeField] WheelNumber wheelNumber00;

    private List<WheelNumber> wheelNumbersList;


    private Transform NumberOnWheelTransform;
    private bool startCheckingForDistanceToStop = false;
    [SerializeField] Transform stopPoint;
    [SerializeField] float speed;

    void Start()
    {        
        wheelNumbersList = new List<WheelNumber>();
        AddWheelNumbersToTheList();
    }


    void FixedUpdate()
    {        
        if(shouldTheWheelSpin)
        {
            wheel.AddTorque(1, ForceMode2D.Force);
        }
        
        rotationSpeed = wheel.rotation;
        CheckforRotationSpeedCap(rotationSpeed);

        if(startCheckingForDistanceToStop == true)
        {
            CheckForDistanceThenStop();
        }
        
    }
    private void AddWheelNumbersToTheList()
    {
        wheelNumbersList.Add(wheelNumber0);
        wheelNumbersList.Add(wheelNumber1);
        wheelNumbersList.Add(wheelNumber2);
        wheelNumbersList.Add(wheelNumber3);
        wheelNumbersList.Add(wheelNumber4);
        wheelNumbersList.Add(wheelNumber5);
        wheelNumbersList.Add(wheelNumber6);
        wheelNumbersList.Add(wheelNumber7);
        wheelNumbersList.Add(wheelNumber8);
        wheelNumbersList.Add(wheelNumber9);
        wheelNumbersList.Add(wheelNumber10);
        wheelNumbersList.Add(wheelNumber11);
        wheelNumbersList.Add(wheelNumber12);
        wheelNumbersList.Add(wheelNumber13);
        wheelNumbersList.Add(wheelNumber14);
        wheelNumbersList.Add(wheelNumber15);
        wheelNumbersList.Add(wheelNumber16);
        wheelNumbersList.Add(wheelNumber17);
        wheelNumbersList.Add(wheelNumber18);
        wheelNumbersList.Add(wheelNumber19);
        wheelNumbersList.Add(wheelNumber20);
        wheelNumbersList.Add(wheelNumber21);
        wheelNumbersList.Add(wheelNumber22);
        wheelNumbersList.Add(wheelNumber23);
        wheelNumbersList.Add(wheelNumber24);
        wheelNumbersList.Add(wheelNumber25);
        wheelNumbersList.Add(wheelNumber26);
        wheelNumbersList.Add(wheelNumber27);
        wheelNumbersList.Add(wheelNumber28);
        wheelNumbersList.Add(wheelNumber29);
        wheelNumbersList.Add(wheelNumber30);
        wheelNumbersList.Add(wheelNumber31);
        wheelNumbersList.Add(wheelNumber32);
        wheelNumbersList.Add(wheelNumber33);
        wheelNumbersList.Add(wheelNumber34);
        wheelNumbersList.Add(wheelNumber35);
        wheelNumbersList.Add(wheelNumber36);
        wheelNumbersList.Add(wheelNumber00);
    }

    private void CheckforRotationSpeedCap(float rotationSpeed)
    {
        if(rotationSpeed>=700)
        {
            wheel.AddTorque(0.1f, ForceMode2D.Force);
        }
    }

    public void Spin()
    {
        Debug.Log("The wheel is spinning");
        shouldTheWheelSpin = true;
        
    }

    public void StopSpinning(int number)
    {
        Debug.Log("Stop Spinning called");

        StartCoroutine(WaitTheStartStoppingProcess(number));        
    }

    IEnumerator WaitTheStartStoppingProcess(int number)
    {
        Debug.Log("Waiting 10 seconds");

        yield return new WaitForSeconds(10);

        shouldTheWheelSpin = false;
        Debug.Log("Toque force stopped");

        CheckWhatNumberToStopOn(number);
    }

    private void CheckWhatNumberToStopOn(int number)
    {
        //number = 0; //test
        Debug.Log("Checking number on list");
        foreach(WheelNumber wheelNumber in wheelNumbersList)
        {
            if(wheelNumber.number == number)
            {
                Debug.Log("Number found on list");
                NumberOnWheelTransform = wheelNumber.transform;
                StartCoroutine(AddDragOverTime());
            }
        }
    }

    private IEnumerator AddDragOverTime()
    {
        Debug.Log("Adding drag started");
        if(wheel.angularDrag < 2)
        {            
            wheel.angularDrag += 0.1f;            
        }

        yield return new WaitForSeconds(1);

        Debug.Log("cycle 2");
        if (wheel.angularDrag < 2)
        {
            wheel.angularDrag += 0.1f;
        }

        yield return new WaitForSeconds(1);

        Debug.Log("cycle 3");
        if (wheel.angularDrag < 2)
        {
            wheel.angularDrag += 0.1f;
        }

        yield return new WaitForSeconds(1);

        Debug.Log("Waiting for number on wheel to be close enough");

        startCheckingForDistanceToStop = true;
        
        yield break;
    }

    private void CheckForDistanceThenStop()
    {
        var distance = Vector2.Distance(new Vector2 (NumberOnWheelTransform.transform.position.x, NumberOnWheelTransform.transform.position.y), new Vector2(stopPoint.transform.position.x, stopPoint.transform.position.y));
        Debug.Log("Checking For distance");
        Debug.Log(distance);
        if(distance < 0.5f)
        {
            wheel.angularDrag += 0.2f;
        }
        
    }
}
