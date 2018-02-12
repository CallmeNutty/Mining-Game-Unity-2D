using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            if (InventoryManager.Inventory.ContainsKey(mineral.name))
            {
                InventoryManager.Inventory[mineral.name] += 1;
            }
            else
            {
                InventoryManager.Inventory.Add(mineral.name, 1);
            }
            InventoryManager.panelInventory.Add(mineral.icon);
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
