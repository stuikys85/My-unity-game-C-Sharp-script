﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{

    private bool inTrigger;
    private GameObject player;

    public inOutCar carman;

    void Update()
    {
        if (inTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                carman.vehicleControl(player);
                inTrigger = false;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        inTrigger = true;
        player = col.gameObject;
    }
    void OnTriggerExit()
    {
        inTrigger = false;
        player = null;
    }
}