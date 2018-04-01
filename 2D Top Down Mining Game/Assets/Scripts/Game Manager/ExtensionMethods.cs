using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ExtensionMethods
{
    //Method which looks at an object
    public static void LookAt2D(this Transform transform, Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //Show Icon in the game
    public static void DisplayIconsInInventoryByIndex(int index, GameObject panel, Sprite[] inventorySlots, List<Item> Inventory)
    {
        //If index in the List isn't empty
        if (inventorySlots[index] != null)
        {
            //Display Sprite in the Slot Gameobject's Image component
            panel.transform.GetChild(index).GetChild(0).GetComponent<Image>().sprite = inventorySlots[index];
            //Make Icon visible
            panel.transform.GetChild(index).GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);

            //Display the amount of items in the Inventory
            panel.transform.GetChild(index).GetChild(0).GetChild(0).GetComponent<Text>().text = Inventory[index].amount.ToString();

        }
        else
        {
            //Make sprite = null
            panel.transform.GetChild(index).GetChild(0).GetComponent<Image>().sprite = null;
            //Hide Icon
            panel.transform.GetChild(index).GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
            //Hide text
            panel.transform.GetChild(index).GetChild(0).GetChild(0).GetComponent<Text>().text = "";
        }
    }

    public static Item FindByID(int ID, List<Item> list)
    {
        for (int k = 0; k < list.Count; k++)
        {
            if (list[k].ID == ID)
            {
                return list[k];
            }
        }

        return null;
    }

    public static Item FindBySprite(Sprite sprite, ItemDatabase itemDatabase)
    {
        for (int k = 0; k < itemDatabase.itemDatabase.Count; k++)
        {
            if (itemDatabase.itemDatabase[k].icon == sprite)
            {
                return itemDatabase.itemDatabase[k];
            }
        }

        return null;
    }
}
