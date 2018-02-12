using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private Image panel;

    public static Dictionary<string, int> Inventory = new Dictionary<string, int>();

    public static List<Sprite> panelInventory = new List<Sprite>();

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E) && panel.gameObject.activeInHierarchy == true)
        {
            ActivatePanel(panel, false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ActivatePanel(panel, true);
        }

        for(int k = 0; k < panel.transform.childCount; k++)
        {
            if (panelInventory.Count <= k)
            {
                break;
            }
            else
            {
                panel.transform.GetChild(k).transform.GetChild(0).GetComponent<Image>().sprite = panelInventory[k];
                panel.transform.GetChild(k).transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
        }

    }

    //Methods which activate and deactivate objects
    public void ActivatePanel(Image gameObject, bool activate)
    {
        gameObject.gameObject.SetActive(activate);
        Time.timeScale = activate == true ? 0 : 1;
    }
}
