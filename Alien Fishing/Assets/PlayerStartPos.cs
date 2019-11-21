using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPos : MonoBehaviour
{
    [SerializeField] Transform spaceShip;

    // Start is called before the first frame update
    void Start()
    {
        spaceShip.position = GameSingleton.Instance.GetShipPos();
        spaceShip.rotation = GameSingleton.Instance.GetShipRot();
        Physics.gravity = spaceShip.up * -9.8f;

        transform.position = GameSingleton.Instance.GetPlayerPos();
        transform.rotation = GameSingleton.Instance.GetPlayerRot();

        string enemyUID = GameSingleton.Instance.GetFishingEnemy();
        if (enemyUID != null)
        {
            Debug.Log("획득");
            DataSingleton.Instance.AddPlayerEnemy(enemyUID);
            GameSingleton.Instance.SetFishingEnemy(null);
        }
    }
    //void Update() {
    //    spaceShip.position = GameSingleton.Instance.GetShipPos();
    //    spaceShip.rotation = GameSingleton.Instance.GetShipRot();
    //    Physics.gravity = spaceShip.up * -9.8f;

    //    transform.position = GameSingleton.Instance.GetPlayerPos();
    //    transform.rotation = GameSingleton.Instance.GetPlayerRot();
    //    Destroy(this);
    //}
    
}
