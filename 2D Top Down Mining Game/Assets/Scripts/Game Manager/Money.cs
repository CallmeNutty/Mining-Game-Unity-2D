﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    [SerializeField]
    private Text moneyText;
    [SerializeField]
    private Image moneyTextBackdrop;

    public int money;

	// Use this for initialization
	void Start ()
    {
        moneyTextBackdrop.color = new Color(moneyText.color.r, moneyText.color.g, moneyText.color.b, 0.25f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        moneyText.text = money + "$";
	}
}