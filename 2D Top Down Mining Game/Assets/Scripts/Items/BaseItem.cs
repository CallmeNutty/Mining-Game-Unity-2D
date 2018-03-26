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
    public int amount;
    public int baseValue;
}

[System.Serializable]
public class Planet : BaseItem
{
    public Item[] inventory;
}
