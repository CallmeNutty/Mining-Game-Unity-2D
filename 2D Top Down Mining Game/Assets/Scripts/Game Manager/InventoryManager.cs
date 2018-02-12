using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static Dictionary<string, int> Inventory = new Dictionary<string, int>();

	// Use this for initialization
	void Start ()
    {
        Inventory.Add("Gulm", 0);
        Inventory.Add("Genrite", 0);
        Inventory.Add("Carocil", 0);
        Inventory.Add("Osmanium", 0);
        Inventory.Add("Glorium", 0);
    }
}
