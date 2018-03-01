using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private Image panel;
    [SerializeField]
    private Image menu;
    [SerializeField]
    private Image eKey;
    [SerializeField]
    private ItemDatabase itemDatabase;

    public static bool eKeyFree = true;

    public List<Item> Inventory = new List<Item>();
	
	// Update is called once per frame
	void Update ()
    {
        //If E is pressed and menu is currently displayed
        if(Input.GetKeyDown(KeyCode.E) && menu.gameObject.activeInHierarchy == true && eKeyFree == true)
        {
            ActivatePanel(menu, false);
        }
        //If E is pressed and menu isn't currently displayed
        else if (Input.GetKeyDown(KeyCode.E) && eKeyFree == true)
        {
            ActivatePanel(menu, true);
        }

        //Activate Inventory Key Prompt
        eKey.gameObject.SetActive(eKeyFree);
    }

    //Method which displays an item on the GUI
    public void AddToInventory(int ID, int amount)
    {
        for (int k = 0; k < itemDatabase.database.Count; k++)
        {
            if (itemDatabase.database[k].ID == ID)
            {
                Inventory.Add(itemDatabase.database[k]);
            }
        }
    }

    //Display text next to item in inventory
    public void ItemCount(int itemCount, int index)
    {
        panel.transform.GetChild(index).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = itemCount.ToString();
    }

    //Methods which activate and deactivate objects
    public void ActivatePanel(Image image, bool activate)
    {
        image.gameObject.SetActive(activate);
        Time.timeScale = activate == true ? 0 : 1;
    }
}
