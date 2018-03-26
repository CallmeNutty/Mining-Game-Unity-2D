using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Declare Variable
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Image menu; //This is the 'E' inventory tab
    [SerializeField]
    private Image eKey;
    [SerializeField]
    private Image toolBox; //The box which shows the item
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
            ExtensionMethods.DisplayIconsInInventory(k, panel, inventorySlots, Inventory);
        }

        //Iterate through all of Inventory
        for(int k = 0; k < Inventory.Count; k++)
        {
            //If 0 copies of this item exist
            if(Inventory[k].amount == 0)
            {
                //Remove from the inventory
                RemoveFromInventory(Inventory[k].icon, Inventory[k]);
            }
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
        //Iterates through itemDatabase
        for (int k = 0; k < itemDatabase.itemDatabase.Count; k++)
        {
            //If an ID matchup is made
            if (itemDatabase.itemDatabase[k].ID == ID)
            {
                //Store Item in a variable
                Item addedItem = itemDatabase.itemDatabase[k];

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

    public void RemoveFromInventory(Sprite icon, Item item)
    {
        Inventory.Remove(item);

        //Iterate through all of inventory slots
        for (int k = 0; k < inventorySlots.Length; k++)
        {
            //This finds the icon of the item that was just removed
            if (inventorySlots[k] == icon)
            {
                //And sets it to null
                inventorySlots[k] = null;
            }
        }

        //Then sort the inventory
        inventorySlots = SortArrayByNull(inventorySlots);
    }  

    //Sort array by putting nulls at the end
    public Sprite[] SortArrayByNull(Sprite[] array)
    {
        //Create two collections with the nulls and nonnulls
        var nulls = array.Where(x => x == null);
        var nonnulls = array.Where(x => x != null);

        //Return an array where the nulls are placed after the nonnulls
        return nonnulls.Concat(nulls).ToArray();
    }

    //Methods which activate and deactivate objects
    public void ActivatePanel(Image image, bool activate)
    {
        image.gameObject.SetActive(activate);
        Time.timeScale = activate == true ? 0 : 1
    }
}
