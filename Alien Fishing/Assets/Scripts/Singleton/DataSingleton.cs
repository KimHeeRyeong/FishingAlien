using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataSingleton : MonoBehaviour
{
    static DataSingleton instance = null;
    public static DataSingleton Instance { get => instance; }

    List<Enemy> enemys;
    List<EnemyDetail> enemyDetails;

    List<Bait> baits;
    List<BaitDetail> baitDetails;

    Player player;
    List<PlayerEnemy> playerEnemys;
    List<PlayerBait> playerBaits;
    bool tutorial = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        initPlayerData();
        InitEnemyData();
        InitBaitData();
        DontDestroyOnLoad(gameObject);
        for(int i = 0;i<10;i++)
            BuyBait("01000");
        for (int i = 0; i < 3; i++)
            BuyBait("01001");
        BuyBait("01002");
    }
    public bool GetTutorial()
    {
        return tutorial;
    }
    public void TutorialComplete()
    {
        tutorial = true;
    }
    void InitEnemyData()
    {
        string str = Resources.Load<TextAsset>("EnemyData/Enemy").ToString();
        enemys = JsonUtility.FromJson<EnemyCollection>(str).enemy;

        string strDetail = Resources.Load<TextAsset>("EnemyData/EnemyDetail").ToString();
        enemyDetails = JsonUtility.FromJson<EnemyDetailCollection>(strDetail).enemyDetail;
    }
    void InitBaitData()
    {
        string str = Resources.Load<TextAsset>("BaitData/Bait").ToString();
        baits = JsonUtility.FromJson<BaitCollection>(str).bait;

        string strDetail = Resources.Load<TextAsset>("BaitData/BaitDetail").ToString();
        baitDetails = JsonUtility.FromJson<BaitDetailCollection>(strDetail).baitDetail;
    }
    void initPlayerData()
    {
        string str = Resources.Load<TextAsset>("PlayerData/Player").ToString();
        player = JsonUtility.FromJson<Player>(str);

        string strEnemy = Resources.Load<TextAsset>("PlayerData/PlayerEnemy").ToString();
        playerEnemys = JsonUtility.FromJson<PlayerEnemyCollection>(strEnemy).playerEnemy;

        string strBait = Resources.Load<TextAsset>("PlayerData/PlayerBait").ToString();
        playerBaits = JsonUtility.FromJson<PlayerBaitCollection>(strBait).playerBait;
    }
    public int PlayerCoin()
    {
        return player.coin;
    }
    public void SetPlayerCoin(int coin)
    {
        player.coin = coin;
    }
    public List<PlayerBait> GetPlayerBaits()
    {
        return playerBaits;
    }
    public PlayerBait FindPlayerBait(string UID)
    {
        return playerBaits.Find(x => x.UIDCODE == UID);
    }
    public BaitDetail[] GetBaitDetail()
    {
        return baitDetails.ToArray();
    }
    public void SetPlayerWearBait(string playerBaitUID)
    {
        player.playerBaitID = playerBaitUID;
    }
    public string GetPlayerWearBait()
    {
        return player.playerBaitID;
    }
    public Bait GetWearBaitData()
    {
        string playrBaitUID = player.playerBaitID;
        string baitUID = playerBaits.Find(x => x.UIDCODE == playrBaitUID).baitID;
        return baits.Find(x => x.UIDCODE == baitUID);
    }
    public Bait[] GetBait()
    {
        return baits.ToArray();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            sound_single.Instance.AllStop();
            Destroy(GameSingleton.Instance.gameObject);
            Destroy(sound_single.Instance.gameObject);
            Destroy(instance.gameObject);
            SceneManager.LoadScene(0);
        }

        //if (Input.GetKeyDown(KeyCode.F10))
        //{
        //    #region player Data
        //    //player data reset
        //    player.coin = 0;
        //    player.playerBaitID = null;
        //    //player bait data reset
        //    playerBaits.Clear();
        //    //player enemy data reset
        //    playerEnemys.Clear();

        //    string str = JsonUtility.ToJson(player);
        //    StreamWriter writer = new StreamWriter("Assets/Resources/PlayerData/Player.json");
        //    writer.Write(str);
        //    writer.Close();

        //    PlayerBaitCollection baitCollection = new PlayerBaitCollection();
        //    baitCollection.playerBait = playerBaits;
        //    string str2 = JsonUtility.ToJson(baitCollection);
        //    StreamWriter writer2 = new StreamWriter("Assets/Resources/PlayerData/PlayerBait.json");
        //    writer2.Write(str2);
        //    writer2.Close();

        //    PlayerEnemyCollection enemyCollection = new PlayerEnemyCollection();
        //    enemyCollection.playerEnemy = playerEnemys;
        //    string str3 = JsonUtility.ToJson(enemyCollection);
        //    StreamWriter writer3 = new StreamWriter("Assets/Resources/PlayerData/PlayerEnemy.json");
        //    writer3.Write(str3);
        //    writer3.Close();
        //    #endregion

        //    int cnt = enemyDetails.Count;
        //    for (int i = 0; i < cnt; i++)
        //    {
        //        enemyDetails[i].gotPlayer = false;
        //    }
        //    EnemyDetailCollection detailCollection = new EnemyDetailCollection();
        //    detailCollection.enemyDetail = enemyDetails;
        //    string str4 = JsonUtility.ToJson(detailCollection);

        //    StreamWriter writer4 = new StreamWriter("Assets/Resources/EnemyData/EnemyDetail.json");
        //    writer4.Write(str4);
        //    writer4.Close();

        //    GameSingleton.Instance.ResetData();
        //}
    }
    public Enemy GetEnemy(string UIDCODE)
    {
        return enemys.Find(x => x.UIDCODE == UIDCODE);
    }
    public void PlayerGotSetting(string UIDCODE)//도감에 잡은 물고기 표시를 위함
    {
        EnemyDetail detail = enemyDetails.Find(x => x.enemyID == UIDCODE);
        if (detail != null)
        {
            detail.gotPlayer = true;
        }
    }
    public void AddPlayerEnemy(string enemyID)
    {
        int cnt = playerEnemys.Count;
        if (cnt >= 99)
            return;

        for (int i = 0; i <= cnt; i++)
        {
            string uid = "001";
            if (i < 10)
            {
                uid += "0";
            }
            uid += i.ToString();
            if (playerEnemys.Find(x => x.UIDCODE == uid) == null)
            {
                Debug.Log("Save " + uid);
                PlayerEnemy playerEne = new PlayerEnemy();
                playerEne.UIDCODE = uid;
                playerEne.enemyID = enemyID;
                playerEnemys.Add(playerEne);
                PlayerGotSetting(enemyID);
                //book set got player
                enemyDetails.Find(x => x.enemyID == enemyID).gotPlayer = true;
                break;
            }
        }
    }

    public List<PlayerEnemy> GetPlayerEnemy()
    {
        return playerEnemys;
    }
    public List<Bait> GetBaitData()
    {
        return baits;
    }

    //=============도감용
    public EnemyDetail[] GetEnemyDetails()
    {
        return enemyDetails.ToArray();
    }
    public bool DetailGotPlayer(string UID) //EnemyDetail - gotplayer 반환
    {
        EnemyDetail detail = enemyDetails.Find(x => x.UIDCODE == UID);

        if (detail != null)
        {
            return detail.gotPlayer;
        }
        return false;
    }
    public string EnemyDetailData(string UID) //EnemyDetail - data 반환
    {
        EnemyDetail detail = enemyDetails.Find(x => x.UIDCODE == UID);

        if (detail != null)
        {
            return detail.data;
        }
        return null;
    }
    public EnemyDetail EnemyDetailDataFromEnemy(string uid)
    {
        return enemyDetails.Find(x => x.enemyID == uid);
    }
    public string EnemyName(string UID) //Enemy - name 반환
    {
        Enemy enemy = enemys.Find(x => x.UIDCODE == UID);

        return enemy.name;
    }
    //도감용================



    //=============상점용(미끼)
    public string BaitImage(string UID) //Bait - imagePath 반환
    {
        BaitDetail detail = baitDetails.Find(x => x.UIDCODE == UID);

        return detail.imagePath;
    }
    public string BaitName(string UID) //Bait - name 반환
    {
        Bait bait = baits.Find(x => x.UIDCODE == UID);

        return bait.name;
    }
    public int BaitCost(string UID) //BaitDetail - cost 반환
    {
        BaitDetail detail = baitDetails.Find(x => x.UIDCODE == UID);

        return detail.cost;
    }
    public string BaitDetailData(string UID) //BaitDetail - data 반환
    {
        BaitDetail detail = baitDetails.Find(x => x.UIDCODE == UID);

        return detail.data;
    }
    public int BaitPower(string UID) //Bait - power 반환
    {
        Bait bait = baits.Find(x => x.UIDCODE == UID);

        return bait.power;
    }
    public int BaitSpeed(string UID) //Bait - speed 반환
    {
        Bait bait = baits.Find(x => x.UIDCODE == UID);

        return bait.speed;
    }
    public int BaitAllure(string UID) //Bait - allure 반환
    {
        Bait bait = baits.Find(x => x.UIDCODE == UID);

        return bait.allure;
    }
    public bool SellEnemy(string playerEnemyUID)
    {
        PlayerEnemy enemy = playerEnemys.Find(x => x.UIDCODE == playerEnemyUID);
        if (enemy != null)
        {
            playerEnemys.Remove(enemy);
            return true;
        }
        return false;

    }
    //상점용(미끼)===================

    public void UseWearBait()
    {
        string playerWearBait = player.playerBaitID;
        playerBaits.Find(x => x.UIDCODE == playerWearBait).count--;
    }
    public void BuyBait(string baitUID)
    {
        if (playerBaits.Find(x => x.baitID == baitUID) != null)
        {
            playerBaits.Find(x => x.baitID == baitUID).count++;
        }
        else
        {
            PlayerBait playerBait = new PlayerBait();
            playerBait.baitID = baitUID;
            playerBait.count = 1;
            playerBait.UIDCODE = "0020" + playerBaits.Count;
            playerBaits.Add(playerBait);
        }
    }
    public PlayerBait FindPlayerBaitFromBait(string baitUID)
    {
        return playerBaits.Find(x => x.baitID == baitUID);
    }
}