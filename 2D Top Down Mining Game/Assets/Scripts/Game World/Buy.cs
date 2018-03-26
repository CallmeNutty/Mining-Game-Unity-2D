using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    [SerializeField]
    private GameObject buySlotGrid;
    [SerializeField]
    private Planets planets;

    public Sprite[] sellInventory;

	// Use this for initialization
	void Start ()
    {
        sellInventory = new Sprite[buySlotGrid.transform.childCount];
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Fill array with Inventory slot images
        for (int k = 0; k < sellInventory.Length; k++)
        {
            sellInventory[k] = planets.inventory[k].icon;
        }

        for (int k = 0; k < sellInventory.Length; k++)
        {
            ExtensionMethods.DisplayIconsInInventory(k, buySlotGrid, sellInventory, planets.inventory);
        }
    }
}
