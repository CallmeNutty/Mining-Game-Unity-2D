using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{

    /* Every item in the game has an ID
     * For example: Gulm Rock could have an ID of 35
     * So, if I wanted to add Gulm Rock to my Inventory, I can use its ID
     * This saves me from having to deal with perfect string dependencies*/

    public List<Item> itemDatabase = new List<Item>();
    public List<Planet> planetDatabase = new List<Planet>();
}
