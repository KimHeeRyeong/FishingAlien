using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] Parabola parabola;
    [SerializeField] GameObject playerCam;
    [SerializeField] MoveToHitPoint baitCam;
    [Space()]
    [SerializeField] Animator rodAnimator;
    [SerializeField] Transform fishingRodPoint;
    [SerializeField] FishingUIController fishingUIController;
    [SerializeField] Transform ship;
    bool fishingRodAppear = false;
    Rigidbody rd;

    // Start is called before the first frame update
    void Awake()
    {
        rodAnimator.gameObject.SetActive(false);
        rd = GetComponent<Rigidbody>();
    }

    //// Update is called once per frame
    void Update()
    {
        if (!playerCam.activeSelf)//player cam 이 켜졌을때만
            return;

        if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.FISHING)
        {
            fishingUIController.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q))//off fishing ui
            {
                fishingUIController.CanFishing(true);
                sound_single.Instance.PlayBait_onf();
                GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
                fishingRodAppear = false;
                rodAnimator.SetTrigger("Disappear");

                //close select bait ui
                fishingUIController.gameObject.SetActive(false);
            }
            //start fishing
            if (parabola.gameObject.activeSelf && parabola.CanFishing())
            {
                fishingUIController.CanFishing(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //close select bait ui
                    fishingUIController.gameObject.SetActive(false);

                    Vector3 hitPoint = parabola.GetHitPoint();
                    baitCam.SetHit(hitPoint);
                    baitCam.SetNextScene(parabola.GetGameSceneNum());

                    GameSingleton.Instance.SetShipPos(ship.position, ship.rotation);
                    GameSingleton.Instance.SetPlayerPos(transform.position, transform.rotation);
                    GameSingleton.Instance.SetBaitStartIndex();
                    parabola.ResetParabola();

                    DataSingleton.Instance.UseWearBait();
                    baitCam.transform.position = fishingRodPoint.position;
                    baitCam.gameObject.SetActive(true);
                    playerCam.SetActive(false);
                }
            }
            else
            {
                fishingUIController.CanFishing(false);
            }
           
        }
        else if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE)
        {
            if (Input.GetKeyDown(KeyCode.Q))// on fishing ui
            {
                //open select bait
                if (fishingUIController.Active())
                {
                    sound_single.Instance.PlayBait_onf();
                    GameSingleton.Instance.SetUIState(GameSingleton.UIState.FISHING);
                    fishingRodAppear = true;
                    rodAnimator.SetTrigger("Appear");
                    rodAnimator.gameObject.SetActive(true);
                    fishingUIController.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            fishingUIController.gameObject.SetActive(false);
        }
    }
        
}