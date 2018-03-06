﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planets : MonoBehaviour
{
    //Declare Variables
    private bool inZone;

    [SerializeField]
    private GameObject eKey;
    [SerializeField]
    private GameObject planetMenu;
    
    //Entered Planet Zone
    void OnTriggerStay2D(Collider2D coll)
    {
        inZone = true;

        //If player has entered the zone
        if (coll.tag == "Player")
        {
            InventoryManager.eKeyFree = false; //Hide other "e key" prompts
            eKey.SetActive(true); //Show this prompt
        }
    }

    //Exited Planet Zone
    void OnTriggerExit2D(Collider2D coll)
    {
        inZone = false;

        if (coll.tag == "Player")
        {
            InventoryManager.eKeyFree = true; //Show other "e key" prompts
            eKey.SetActive(false); //Hide this prompt
        }
    }

    void Update()
    {
        //If E is down and menu is not currently open and in zone
        if (Input.GetKeyDown(KeyCode.E) && inZone == true && planetMenu.activeInHierarchy == false)
        {
            planetMenu.SetActive(true); //Show planet UI
            Time.timeScale = 0;
        }
        //Else if E is down, menu is active and in zone
        else if (Input.GetKeyDown(KeyCode.E) && inZone == true && planetMenu.activeInHierarchy == true)
        {
            planetMenu.SetActive(false); //Hide planet UI
            Time.timeScale = 1;
        }
    }
}
