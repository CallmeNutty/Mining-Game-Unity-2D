using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    [SerializeField]
    private GameObject planetMenu;
    [SerializeField]
    private GameObject sellSlotGrid;
    private Planets thisPlanet;
    [SerializeField]
    private InventoryManager inventoryManager;
    [SerializeField]
    private ItemDatabase itemDatabase;
    [SerializeField]
    private Sprite[] sellInventory;

	// Use this for initialization
	void Start ()
    {
        sellInventory = new Sprite[sellSlotGrid.transform.childCount];
    }
	
	// Update is called once per frame
	void Update ()
    {
        thisPlanet = Planets.currentPlanet;

        //Sell Inventory slots are equal to the slots in the Inventory
        sellInventory = inventoryManager.inventorySlots;

        //This simply allows you to exit back to the planet menu
        if (Input.GetKeyUp(KeyCode.E))
        {
            gameObject.SetActive(false);
            planetMenu.SetActive(true);
        }

        for (int k = 0; k < inventoryManager.inventorySlots.Length; k++)
        {
            //Displays icon inside the "sell" section of the buy/ sell menu
            ExtensionMethods.DisplayIconsInInventoryByIndex(k, sellSlotGrid, sellInventory, inventoryManager.Inventory);
        }

        for (int k = 0; k < sellSlotGrid.transform.childCount; k++)
        {
            if (sellInventory[k] != null)
            {
                //Updates price of item based on the CalculatePrice method
                ExtensionMethods.FindBySprite(sellInventory[k], itemDatabase).eachPlanet.Find(x => x.ID == thisPlanet.ID).price
                    = CalculatePrice(ExtensionMethods.FindBySprite(sellInventory[k], itemDatabase).ID);
            }
        }
    }

    //This method will take the ID of an item, use it's price and apply the specific calculations
    public int CalculatePrice(int ID)
    {
        float baseCost = ExtensionMethods.FindByID(ID, itemDatabase.itemDatabase).baseValue;
        float currentDemand = ExtensionMethods.FindByID(ID, itemDatabase.itemDatabase).eachPlanet.Find(x => x.ID == thisPlanet.ID).demand;
        float currentRelations = thisPlanet.relations;

        return Mathf.RoundToInt(baseCost * currentDemand * currentRelations);
    }
}
