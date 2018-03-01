using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanyManager : MonoBehaviour
{
    //Declare Variables
    public string companyName;

    [SerializeField]
    private Text companyNameText;

	// Use this for initialization
	void Start ()
    {
        companyNameText.text = companyName;
	}
}
