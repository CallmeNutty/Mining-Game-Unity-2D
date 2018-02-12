using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private InventoryManager inventoryManager;

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Collided with projectiles
        if (coll.gameObject.tag == "Bullet")
        {
            //If mineral has already been collected
            if (InventoryManager.Inventory.ContainsKey(mineral.name))
            {
                InventoryManager.Inventory[mineral.name] += 1; //Add '1' to the stack(amount collected)
                inventoryManager.ItemCount(InventoryManager.Inventory[mineral.name]); //Display correct text
            }
            else //If this is the first copy
            {
                InventoryManager.Inventory.Add(mineral.name, 1); //Create new entry in direction
                inventoryManager.AddToInventory(InventoryManager.Inventory[mineral.name], mineral.icon); //Display on GUI
                inventoryManager.ItemCount(InventoryManager.Inventory[mineral.name]); //Display correct text
            }

            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class Mineral
    {
        public string name;
        public int health;
        public Sprite icon;
    }

    public Mineral mineral;
}
