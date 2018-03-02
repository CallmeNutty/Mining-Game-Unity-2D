using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private InventoryManager inventoryManager;
    [SerializeField]
    private ItemDatabase itemDatabase;
    [SerializeField]
    private ThisItem thisItem;

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Collided with projectiles
        if (coll.gameObject.tag == "Bullet")
        {
            //If this item is already in the Inventory
            if (inventoryManager.Inventory.Any(x => x.ID == thisItem.ID))
            {
                inventoryManager.Inventory.Find(x => x.ID == thisItem.ID).amount++; //Add to Inventory
                Destroy(coll.gameObject); //Destroy Bullet
                Destroy(gameObject); //Destroy self
            }
            else //If this is the first copy
            {
                inventoryManager.AddToInventory(1, 1); //Add class to Inventory List
                inventoryManager.AddToInventorySlots(itemDatabase.database.Find(x => x.ID == 1).icon);
                Destroy(coll.gameObject); //Destroy Bullet
                Destroy(gameObject); //Destroy Self
            }
        }
    }
}
