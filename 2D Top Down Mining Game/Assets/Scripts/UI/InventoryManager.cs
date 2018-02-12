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

    public static Dictionary<string, int> Inventory = new Dictionary<string, int>();
    public static List<string> InventoryList = new List<string>();
	
	// Update is called once per frame
	void Update ()
    {
        //If E is pressed and menu isn't currently displayed
        if(Input.GetKeyDown(KeyCode.E) && menu.gameObject.activeInHierarchy == true)
        {
            ActivatePanel(menu, false);
        }
        //If E is pressed and menu is currently displayed
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ActivatePanel(menu, true);
        }
    }

    //Method which displays an item on the GUI
    public void AddToInventory(int itemCount, string name, Sprite icon)
    {
        panel.transform.GetChild(Inventory.Count - 1).transform.GetChild(0).GetComponent<Image>().sprite = icon; //Display icon
        panel.transform.GetChild(Inventory.Count - 1).transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255); //Make icon visible
        InventoryList.Add(name);
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
