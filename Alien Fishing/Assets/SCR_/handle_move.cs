using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handle_move : MonoBehaviour
{
    public Text handle_text; //조종문구
    public Text handle_out;

    [Space()]
    public GameObject main; //카메라 전환용
    public GameObject two;
    public Light space_light;

    [Space()]
    public GameObject player;
    public GameObject ship; //우주선

    player_move playerMove;
    Rigidbody playerRd;

    RaycastHit target_plane;
    float ray_range = 50.0f;
    // Update is called once per frame

    bool on_tri = false;
    // Update is called once per frame
    private void Awake()
    {
        playerMove = player.GetComponent<player_move>();
        playerRd = player.GetComponent<Rigidbody>();

        two.SetActive(false);
        handle_text.enabled = false;
        handle_out.enabled = false;
    }

    private void Update()
    {
        if (!on_tri)
            return;

        if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.NONE)
        {
            handle_text.enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                sound_single.Instance.PlayStart();
                Debug.Log("in");
                GameSingleton.Instance.SetUIState(GameSingleton.UIState.DRIVE);
                playerMove.move = ship;
                playerMove.main = two.GetComponent<Camera>();

                playerRd.isKinematic = true;
                space_light.enabled = true;

                two.SetActive(true);
                main.SetActive(false);
                handle_text.enabled = false;
                handle_out.enabled = true;
            }
        }
        else if (GameSingleton.Instance.GetUIState() == GameSingleton.UIState.DRIVE)
        {
            handle_out.enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!sound_single.Instance.IsPlayEnEnd())
                {
                    sound_single.Instance.PlayEnEnd();
                }
                sound_single.Instance.StopEnMiddle();
                sound_single.Instance.StopEnStart();

                playerMove.main.transform.localPosition = new Vector3(0, 15.8f, 102.3f);
                playerMove.main.fieldOfView = 60;
                Debug.Log("out");
                GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
                playerMove.move = player;
                playerMove.main = main.GetComponent<Camera>();

                playerRd.isKinematic = false;
                Physics.gravity = ship.transform.up * -9.8f;
                space_light.enabled = false;

                main.SetActive(true);
                two.SetActive(false);
                handle_text.enabled = true;
                handle_out.enabled = false;
            }
        }
        else
        {
            handle_text.enabled = false;
            handle_out.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            on_tri = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            on_tri = false;
            handle_text.enabled = false;
            handle_out.enabled = false;
        }
    }
}
