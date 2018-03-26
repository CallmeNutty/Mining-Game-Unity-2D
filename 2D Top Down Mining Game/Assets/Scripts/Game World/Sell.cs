using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell : MonoBehaviour
{
    [SerializeField]
    private GameObject sellSlots;
    [SerializeField]
    private InventoryManager inventoryManager;
    [SerializeField]
    private ItemDatabase itemDatabase;
    [SerializeField]
    private Sprite[] sellInventory;

	// Use this for initialization
	void Start ()
    {
        sellInventory = new Sprite[sellSlots.transform.childCount];
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Sell Inventory slots are equal to the slots in the Inventory
        sellInventory = inventoryManager.inventorySlots;

        for (int k = 0; k < inventoryManager.inventorySlots.Length; k++)
        {
            //Displays icon inside the "sell" section of the buy/ sell menu
            ExtensionMethods.DisplayIconsInInventory(k, sellSlots, sellInventory, inventoryManager.Inventory);
        }
    }
}
