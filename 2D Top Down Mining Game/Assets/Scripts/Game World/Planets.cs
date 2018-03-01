using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planets : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private GameObject eKey;
    [SerializeField]
    private GameObject planetMenu;
    
    //Entered Planet Zone
    void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            planetMenu.SetActive(true); //Show planet UI
            Time.timeScale = 0;
        }
        //If player has entered the zone
        else if (coll.tag == "Player")
        {
            InventoryManager.eKeyFree = false; //Hide other "e key" prompts
            eKey.SetActive(true); //Show this prompt
        }
    }

    //Exited Planet Zone
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            InventoryManager.eKeyFree = true; //Show other "e key" prompts
            eKey.SetActive(false); //Hide this prompt
        }
    }
}
