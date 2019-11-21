using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Bait
{
    public string UIDCODE;
    public string name;
    public int power;
    public int speed;
    public int allure;
}
[Serializable]
public class BaitDetail//상점창
{
    public string UIDCODE;
    public string baitID;
    public string data;
    public string imagePath;
    public int cost;
}
#region Collection
[Serializable]
public class BaitCollection
{
    public List<Bait> bait = new List<Bait>();
}
[Serializable]
public class BaitDetailCollection
{
    public List<BaitDetail> baitDetail = new List<BaitDetail>();
}
#endregion