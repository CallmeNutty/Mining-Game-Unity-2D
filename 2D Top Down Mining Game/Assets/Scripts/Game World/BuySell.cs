using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySell : MonoBehaviour
{
    [SerializeField]
    private GameObject sellSlots;
    [SerializeField]
    private InventoryManager inventoryManager;
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
        sellInventory = inventoryManager.inventorySlots;

        for (int k = 0; k < inventoryManager.inventorySlots.Length; k++)
        {
            ExtensionMethods.DisplayIconsInInventory(k, sellSlots, sellInventory, inventoryManager.Inventory);
        }
    }
}
