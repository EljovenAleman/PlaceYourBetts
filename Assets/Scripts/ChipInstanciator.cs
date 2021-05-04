using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipInstanciator : MonoBehaviour
{
    [SerializeField] GameObject chipPrefab;

    void Awake()
    {
        InstanciateChips();
    }

    private void InstanciateChips()
    {
        for(int i = 0; i<100; i++)
        {
            Instantiate(chipPrefab, new Vector2(10, 10), Quaternion.identity);
        }
    }
}
