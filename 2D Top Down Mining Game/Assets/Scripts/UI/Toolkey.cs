using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
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
            Item item = ExtensionMethods.FindBySprite(gameObject.transform.GetChild(0).GetComponent<Image>().sprite, itemDatabase);
            itemName.text = item.name;
            toolTip.gameObject.SetActive(true);

            //If this is part of the buy/sell menu
            if (planet == true)
            {
                print(item.name);
                cost.gameObject.SetActive(true);
                cost.text = item.eachPlanet.Find(x => x.ID == Planets.currentPlanet.ID).price.ToString();
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
        print(gameObject.name);
    }
}
