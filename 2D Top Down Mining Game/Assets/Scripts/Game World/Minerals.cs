using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            InventoryManager.Inventory[mineral.name] += 1;
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class Mineral
    {
        public string name;
        public int health;
    }

    public Mineral mineral;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
