using System;
using System.Collections.Generic;
[Serializable]
public class Player
{
    public string UIDCODE;
    public string name;
    public int coin;
    public string playerBaitID;
}
[Serializable]
public class PlayerBait
{
    public string UIDCODE;//00200~
    public string baitID;
    public int count;
}

[Serializable]
public class PlayerEnemy//플레이어가 획득한 enemy
{
    public string UIDCODE;
    public string enemyID;
}

#region Collections
[Serializable]
public class PlayerEnemyCollection
{
    public List<PlayerEnemy> playerEnemy = new List<PlayerEnemy>();
}
[Serializable]
public class PlayerBaitCollection
{
    public List<PlayerBait> playerBait = new List<PlayerBait>();
}
#endregion