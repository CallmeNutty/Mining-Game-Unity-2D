using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem
{
    public string name;
    public int ID;
    public Sprite icon;
}

[System.Serializable]
public class Item : BaseItem
{
    [HideInInspector]
    public int amount;
    public int baseValue;
    public List<Planet> eachPlanet = new List<Planet>();
}

[System.Serializable]
public class Planet
{
    public string name;
    public int ID;
    public int price;
    public float demand;
    public int amount;
}
