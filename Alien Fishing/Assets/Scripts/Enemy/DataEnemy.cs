using System;
using System.Collections.Generic;

[Serializable]
public class Enemy {
    public string UIDCODE;
    public string name;
    public int rareLevel;
    public int power;
    public int speed;
    public int allureResistance;
    public int cost;
    public string imagePath;
}
[Serializable] 
public class EnemyDetail
{
    public string UIDCODE;
    public string enemyID;
    public string typeID;
    public string data;
    public bool gotPlayer;
}
[Serializable]
public class EnemyType
{
    public string UIDCODE;
    public string typeData;
}
#region Collection
[Serializable]
public class EnemyCollection {
    public List<Enemy> enemy = new List<Enemy>();
}
[Serializable]
public class EnemyDetailCollection
{
    public List<EnemyDetail> enemyDetail = new List<EnemyDetail>();
}
[Serializable]
public class EnemyTypeCollection
{
    public List<EnemyType> enemyType
        = new List<EnemyType>();
}
#endregion