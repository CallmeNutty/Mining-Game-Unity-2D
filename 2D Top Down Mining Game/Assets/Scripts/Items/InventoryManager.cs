using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Image menu;
    [SerializeField]
    private Image eKey;
    [SerializeField]
    private Image toolBox;
    [SerializeField]
    private ItemDatabase itemDatabase;

    public static bool eKeyFree = true;

    public Sprite[] inventorySlots;
    public List<Item> Inventory = new List<Item>();


    // Use this for initialization
    void Start()
    {
        //Set size of array
        inventorySlots = new Sprite[panel.transform.childCount];

        //Fill array with Inventory slot images
        for(int k = 0; k < inventorySlots.Length; k++)
        {
            inventorySlots[k] = panel.transform.GetChild(k).GetChild(0).GetComponent<Image>().sprite;
        }
    }


    // Update is called once per frame
    void Update ()
    {
        //Every frame display all the icons in the inventory correctly
        for(int k = 0; k < inventorySlots.Length; k++)
        {
            DisplayIcon(k, true);
        }

        //If E is pressed and menu is currently displayed
        if(Input.GetKeyDown(KeyCode.E) && menu.gameObject.activeInHierarchy == true && eKeyFree == true)
        {
            ActivatePanel(toolBox, false);
            ActivatePanel(menu, false);
        }
        //If E is pressed and menu isn't currently displayed
        else if (Input.GetKeyDown(KeyCode.E) && eKeyFree == true)
        {
            ActivatePanel(menu, true);
        }

        //Activate Inventory Key Prompt
        eKey.gameObject.SetActive(eKeyFree);
    }


    //Adds item to the inventory
    public void AddToInventory(int ID, int amount)
    {
        //Iterates through database
        for (int k = 0; k < itemDatabase.database.Count; k++)
        {
            //If an ID matchup is made
            if (itemDatabase.database[k].ID == ID)
            {
                //Store Item in a variable
                Item addedItem = itemDatabase.database[k];

                Inventory.Add(addedItem); //Add item to Inventory
                addedItem.amount++; //Sets amount to 1 by default
            }
        }
    }

    //Add icon to appropriate inventory slots
    public void AddToInventorySlots(Sprite icon)
    {
        //Iterate through all the inventorySlots (Array)
        for(int k = 0; k < inventorySlots.Length; k++)
        {
            //If slot is free
            if(inventorySlots[k] == null)
            {
                inventorySlots[k] = icon;
                break;
            }
        }
    }

    //Show Icon in the game
    public void DisplayIcon(int index, bool show)
    {
        //If the icon should be shown and index in the List isn't empty
        if (show == true && inventorySlots[index] != null)
        {
            //Display Sprite in the Slot Gameobject's Image component
            panel.transform.GetChild(index).GetChild(0).GetComponent<Image>().sprite = inventorySlots[index];
            //Make Icon visible
            panel.transform.GetChild(index).GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            //Display the amount of items in the Inventory
            panel.transform.GetChild(index).GetChild(0).GetChild(0).GetComponent<Text>().text = Inventory[index].amount.ToString();
        }
    }

    //Methods which activate and deactivate objects
    public void ActivatePanel(Image image, bool activate)
    {
        image.gameObject.SetActive(activate);
        Time.timeScale = activate == true ? 0 : 1;
    }
}
