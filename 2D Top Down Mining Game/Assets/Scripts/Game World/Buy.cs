using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    /*
     * This Script is responsible for handling the buying section of a planet
     * It also handles calculating the price for these items
     * Please note that every planet will always sell you the same items
    */

    //Declare Variables
    [SerializeField]
    private GameObject buySlotGrid;
    private Planets thisPlanet;
    [SerializeField]
    private ItemDatabase itemDatabase;
    private Sprite[] buySlots;

    //Use this for initialization
    void Start()
    {
        thisPlanet = gameObject.GetComponent<Planets>();

        buySlots = new Sprite[buySlotGrid.transform.childCount];

        //Fill array with specific item sprite inside each box
        for(int k = 0; k < buySlotGrid.transform.childCount; k++)
        {
            buySlots[k] = buySlotGrid.transform.GetChild(k).transform.GetChild(0).GetComponent<Image>().sprite;
        }
    }

    //Update is called once per frame
    void Update()
    {
        for (int k = 0; k < buySlotGrid.transform.childCount; k++)
        {
            if (Planets.currentPlanet != null)
            {
                //Used for price
                Planet thisItem = ExtensionMethods.FindBySprite(buySlots[k], itemDatabase).eachPlanet.Find(x => x.ID == thisPlanet.ID);

                //Used for amount
                Planet currentItem = ExtensionMethods.FindBySprite(buySlots[k], itemDatabase).eachPlanet.Find(x => x.ID == Planets.currentPlanet.ID);

                //Updates price of item based on the CalculatePrice method
                thisItem.price = CalculatePrice(ExtensionMethods.FindBySprite(buySlots[k], itemDatabase).ID);

                //Displays amount
                buySlotGrid.transform.GetChild(k).GetChild(0).GetChild(0).GetComponent<Text>().text = currentItem.amount.ToString();
            }
        }
    }

    //This method will take the ID of an item, use it's price and apply the specific calculations
    public int CalculatePrice(int ID)
    {
        float baseCost = ExtensionMethods.FindByID(ID, itemDatabase.itemDatabase).baseValue;
        float currentDemand = ExtensionMethods.FindByID(ID, itemDatabase.itemDatabase).eachPlanet.Find(x => x.ID == thisPlanet.ID).demand;
        float currentRelations = thisPlanet.relations;

        print(Mathf.RoundToInt(baseCost * currentDemand * currentRelations));
        return Mathf.RoundToInt(baseCost * currentDemand * currentRelations);
    }
}
