using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            InventoryManager.Inventory.Add(mineral.name);
            Panel.panelInventory.Add(mineral.icon);
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
