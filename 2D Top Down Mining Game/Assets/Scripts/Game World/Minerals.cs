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

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Collided with projectiles
        if (coll.gameObject.tag == "Bullet")
        {
            if (inventoryManager.Inventory.Any(x => x.ID == 1))
            {
                inventoryManager.Inventory.Find(x => x.ID == 1).amount++; //Add to Inventory
                Destroy(coll.gameObject);
                Destroy(gameObject);
            }
            else
            {
                inventoryManager.AddToInventory(1, 1);
                Destroy(coll.gameObject);
                Destroy(gameObject);
            }
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
