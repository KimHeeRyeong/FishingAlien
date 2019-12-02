using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    [SerializeField] PlayerBaits playerBaits;
    [SerializeField] GameObject DefaultCam;
    [SerializeField] Transform baitStartPos;
    [SerializeField] Transform cable;
    [Space()]
    [SerializeField] FishingCable fishingCable;
    [SerializeField] BackgroundMove backgroundMove;
    [SerializeField] MapManager mapManager;
    // Start is called before the first frame update
    void Start()
    {
        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
        GameObject activeBait = playerBaits.GetPlayerWearBait();
        //활성화된 미끼가 없을때 씬 변경
        if (activeBait==null)
        {
            GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
            sound_single.Instance.AllStop();
            SceneManager.LoadScene(1);
            return;
        }

        activeBait.transform.parent = null;
        int startIndex = GameSingleton.Instance.GetBaitStartIndex();
        activeBait.transform.position = baitStartPos.GetChild(startIndex).position;
        cable.position = baitStartPos.GetChild(startIndex).position + new Vector3(0, 80, 0);
        cable.GetComponent<FollowXY>().SetFollw(activeBait.transform);
        activeBait.SetActive(true);
        mapManager.SetNowMap(startIndex);
        fishingCable.SetBait(activeBait.transform);
        fishingCable.gameObject.SetActive(true);
        backgroundMove.SetBait(activeBait.transform);

        Destroy(playerBaits.gameObject);
        Destroy(DefaultCam.gameObject);
        Destroy(this);
    }
}
