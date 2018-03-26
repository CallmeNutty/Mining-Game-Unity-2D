using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private Text moneyText;

    public int money;
	
	// Update is called once per frame
	void Update ()
    {
        //Show money on UI
        moneyText.text = money.ToString();
	}
}
