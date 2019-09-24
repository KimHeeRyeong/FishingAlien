using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Baits
{
    public List<Bait> bait = new List<Bait>();
}
[Serializable]
public class Equips
{
    public List<Equip> equip = new List<Equip>();
}
[Serializable]
public class SingleUses
{
    public List<SingleUse> singleUse = new List<SingleUse>();
}

[Serializable]
public class Item
{
    public string name;
    public int cost;
    public int creditLimit;
    public string explain;
    public string imagePath;
}
[Serializable]
public class Bait : Item
{
    public int power;
    public int speed;
    public int allure;
}
[Serializable]
public class Equip : Item
{
    public int power;
}
[Serializable]
public class SingleUse:Item
{
}