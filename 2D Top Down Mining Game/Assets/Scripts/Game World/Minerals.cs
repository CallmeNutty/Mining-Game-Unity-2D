using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private int health;

    [SerializeField]
    private InventoryManager inventoryManager;
    [SerializeField]
    private ItemDatabase itemDatabase;
    [SerializeField]
    private SoundManager soundManager;
    [SerializeField]
    private AudioClip[] rockHitSounds;
    [SerializeField]
    private AudioClip collectItemSound;
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private Firing firing;
    [SerializeField]
    private ThisItem thisItem;

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Collided with projectiles
        if (coll.gameObject.tag == "Bullet")
        {
            Instantiate(particle, transform.position, Quaternion.identity);

            //If bullet will destroy mineral
            if (health - firing.damagePerShot <= 0)
            {
                soundManager.PlaySoundEffect(collectItemSound);

                //If this item is already in the Inventory
                if (inventoryManager.Inventory.Any(x => x.ID == thisItem.ID))
                {
                    inventoryManager.Inventory.Find(x => x.ID == thisItem.ID).amount++; //Add to Inventory
                    Destroy(coll.gameObject); //Destroy Bullet
                    Destroy(gameObject); //Destroy self
                }
                else //If this is the first copy
                {
                    inventoryManager.AddToInventory(thisItem.ID, 1); //Add class to Inventory List
                    inventoryManager.AddToInventorySlots(itemDatabase.itemDatabase.Find(x => x.ID == thisItem.ID).icon);
                    Destroy(coll.gameObject); //Destroy Bullet
                    Destroy(gameObject); //Destroy Self
                }
            }
            else
            {
                //Play random rock sound
                soundManager.PlayRandomSoundEffect(rockHitSounds);
                health -= firing.damagePerShot;
                Destroy(coll.gameObject); //Destroy Bullet
            }
        }
    }
}
