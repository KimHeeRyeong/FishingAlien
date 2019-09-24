using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Items
{
    Baits baits;
    Equips equips;
    SingleUses SingleUses;
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
public class Baits
{
    List<Bait> bait = new List<Bait>();
}
[Serializable]
public class Bait
{
    string name;
    int power;
    int speed;
    int allure;
    int creditLimit;
    int cost;
}
[Serializable]
public class Equips
{
    List<Equip> equip = new List<Equip>();
}
[Serializable]
public class Equip
{
    string name;
    int power;
    int creditLimit;
    int cost;
}
[Serializable]
public class SingleUses
{
    List<SingleUse> singleUse = new List<SingleUse>();
}
[Serializable]
public class SingleUse
{
    string name;
    int creditLimit;
    int cost;
}