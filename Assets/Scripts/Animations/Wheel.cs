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

    private List<WheelNumber> wheelNumbersList;


    private Transform atractPoint;
    private bool startPointAtraction = false;
    [SerializeField] Transform pointOfAtraction;
    [SerializeField] float speed;

    void Start()
    {        
        wheelNumbersList = new List<WheelNumber>();
        AddWheelNumbersToTheList();
    }


    void FixedUpdate()
    {
        //Debug.Log(wheelNumber0.transform.position);
        if(shouldTheWheelSpin)
        {
            wheel.AddTorque(1, ForceMode2D.Force);
        }
        
        rotationSpeed = wheel.rotation;
        CheckforRotationSpeedCap(rotationSpeed);

        if(startPointAtraction == true)
        {
            AtractPoints();
        }
        
    }
    private void AddWheelNumbersToTheList()
    {
        wheelNumbersList.Add(wheelNumber0);
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

        StartCoroutine(WaitThenStopSpinningAtNumber(number));        
    }

    IEnumerator WaitThenStopSpinningAtNumber(int number)
    {
        Debug.Log("Stop Spinning Coroutine starterd");

        yield return new WaitForSeconds(10);

        shouldTheWheelSpin = false;

        StopAtNumber(number);
    }

    private void StopAtNumber(int number)
    {
        number = 0; //test

        foreach(WheelNumber wheelNumber in wheelNumbersList)
        {
            if(wheelNumber.number == number)
            {
                atractPoint = wheelNumber.transform;
                StartCoroutine(AddDragAtPointOverTime());
            }
        }
    }

    private IEnumerator AddDragAtPointOverTime()
    {
        Debug.Log("Coroutine started");
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

        Debug.Log("Atraction started");

        startPointAtraction = true;
        
        yield break;
    }

    private void AtractPoints()
    {
        var distance = Vector2.Distance(new Vector2 (atractPoint.transform.position.x, atractPoint.transform.position.y), new Vector2(pointOfAtraction.transform.position.x, pointOfAtraction.transform.position.y));
        Debug.Log("AtractPoints Called");
        Debug.Log(distance);
        if(distance < 0.5f)
        {
            wheel.angularDrag += 0.2f;
        }
        
    }
}
