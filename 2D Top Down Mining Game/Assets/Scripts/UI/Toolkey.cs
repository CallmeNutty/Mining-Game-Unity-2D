using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toolkey : MonoBehaviour
{
    [SerializeField]
    private Image toolTip;
    [SerializeField]
    private Text itemName;
    [SerializeField]
    private Text cost;

    public ItemDatabase itemDatabase;
    [SerializeField]
    private Money money;
    [SerializeField]
    private InventoryManager inventoryManager;
    [SerializeField]
    private SoundManager soundManager;
    [SerializeField]
    private AudioClip boughtItemSound;
	
	// Update is called once per frame
	void Update ()
    {
        //Tooltip will always follow the mouse (plus/negative the specified co-ordinates)
        toolTip.rectTransform.position = new Vector3 (Input.mousePosition.x + 60, Input.mousePosition.y - 50);
	}

    //This method will be accessed inside the scene view (button event)
    public void ShowToolKey(bool planet)
    {
        //If inventory slot does not contain an item
        if (gameObject.transform.GetChild(0).GetComponent<Image>().sprite == null)
        {
            print("Empty :)");
        }
        else
        {
            //Find the item that is present in the slot
            Item thisItem = ExtensionMethods.FindBySprite(gameObject.transform.GetChild(0).GetComponent<Image>().sprite, itemDatabase);
            itemName.text = thisItem.name;
            toolTip.gameObject.SetActive(true);
            //If this is part of the buy/sell menu
            if (planet == true)
            {
                print(thisItem.name);
                cost.gameObject.SetActive(true);
                //Displays cost
                cost.text = thisItem.eachPlanet.Find(x => x.ID == Planets.currentPlanet.ID).price.ToString();
            }
        }
    }

    public void HideToolKey()
    {
        cost.gameObject.SetActive(false);
        toolTip.gameObject.SetActive(false);
    }

    public void BuyItem()
    {
        //Get item that is present here
        Planet thisItem = ExtensionMethods.FindBySprite(gameObject.transform.GetChild(0).GetComponent<Image>().sprite, itemDatabase).eachPlanet.Find(x => x.ID == Planets.currentPlanet.ID);

        //Checks if player can actually afford the item and Planet has enough
        if (thisItem.amount > 0 && money.money > thisItem.price)
        {
            money.money -= thisItem.price;
            thisItem.amount--;
        }
    }

    public void SellItem()
    {
        if (gameObject.transform.GetChild(0).GetComponent<Image>().sprite != null)
        {
            //Get item that is present here
            Planet thisItem = ExtensionMethods.FindBySprite(gameObject.transform.GetChild(0).GetComponent<Image>().sprite, itemDatabase).eachPlanet.Find(x => x.ID == Planets.currentPlanet.ID);

            //Checks if player can actually afford the item and Planet has enough
            money.money += thisItem.price;
            //Remove 1 from Inventory
            inventoryManager.Inventory.Find(x => x == ExtensionMethods.FindBySprite(gameObject.transform.GetChild(0).GetComponent<Image>().sprite, itemDatabase)).amount--;
            soundManager.PlaySoundEffect(boughtItemSound);
        }
        else
        {
            print("Empty Click! No Sell for you :)");
        }
    }
}
