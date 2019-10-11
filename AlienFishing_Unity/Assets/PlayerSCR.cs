using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSCR : MonoBehaviour
{
    //플레이어 캐릭터 물리 관련
    Rigidbody playerRD;
    public float speed = 3.0f;

    //메뉴 패널
    public GameObject QuestPanel = null;
    public GameObject StorePanel = null;
    public GameObject BookPanel = null;
    public GameObject MenuPanel = null;

    public GameObject StoreOK = null;

    //낚시 관련
    public GameObject FishingText = null; //낚시 가능 에리어 알림 텍스트
    public GameObject FishingRod = null; //낚싯대(다가가서 낚시하기 누르면 착용함)
    public GameObject Durability = null; //미끼 내구도
    public GameObject DontFishing = null; //미끼 내구도 0일시 낚시 불가 알림 텍스트

    public Camera maincamera = null;

    public bool storecheck = false;
    public bool menucheck = false;

    void Awake()
    {
        playerRD = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //패널이 열렸을 땐 움직임을 멈춰야하므로 전부 false일 때 다음 함수 실행
        if (MenuPanel.activeSelf == false && QuestPanel.activeSelf == false &&
            StorePanel.activeSelf == false && BookPanel.activeSelf == false) 
        {
            Move(h, v);
            Turnning();
        }

        Book();
        Menu();
        StartCoroutine(Fishing());
    }

    void Move(float h, float v)
    {
        Vector3 move = new Vector3(h, 0.0f, v);
        move = maincamera.transform.TransformDirection(move);
        move *= speed;
        playerRD.MovePosition(transform.position + move);
    }

    public void Turnning() //마우스 방향에 따라 플레이어 회전
    {
        float yaw = 0.0f;
        float speed = 2.0f;

        yaw += speed * Input.GetAxis("Mouse X");
        Vector3 look = new Vector3(0, yaw, 0);
        transform.Rotate(look);
    }

    IEnumerator Fishing() //IEnumerator는 StartCoroutine으로 호출
    {
        //프로젝트 연결되고나면 낚시 시작하는 버튼으로 수정(점프 필요 없음 임시 구현)
        if (FishingText.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Durability.GetComponent<Slider>().value == 0)
                {
                    DontFishing.SetActive(true);
                    yield return new WaitForSeconds(1);
                    DontFishing.SetActive(false);
                }
                else //낚시 에리어 위에서 점프 구현해둔 부분. 리지드바디 y축 프리즈 풀고 써야함.
                {
                    Debug.Log("Jump UP OK");
                    FishingRod.SetActive(true);
                    playerRD.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
                    yield return new WaitForSeconds(2);
                    playerRD.AddForce(new Vector3(0, -10, 0), ForceMode.Impulse);
                }
            }
        }
    }

    private void Menu() //ESC 메인 메뉴(메인으로/이어서/게임 종료)
    {
        if (MenuPanel.activeSelf != true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MenuPanel.SetActive(true);
                Debug.Log("Menu On");
                menucheck = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MenuPanel.SetActive(false);
                Debug.Log("Menu Off");
                menucheck = false;
            }
        }
    }

    private void Book() //도감
    {
        if (BookPanel.activeSelf != true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                BookPanel.SetActive(true);
                Debug.Log("Book On");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                BookPanel.SetActive(false);
                Debug.Log("Book Off");
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Quest"))
        {
            Debug.Log("Quest Enter");
            QuestPanel.SetActive(true);
        }

        if (collider.gameObject.CompareTag("Store"))
        {
            Debug.Log("Store Enter");
            StoreOK.SetActive(true);
            storecheck = true;
        }

        if (collider.gameObject.CompareTag("Fishing area"))
        {
            Debug.Log("Fishing area Enter");
            FishingText.SetActive(true);
            Durability.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Quest"))
        {
            Debug.Log("Quest Exit");
            QuestPanel.SetActive(false);
        }

        if (other.gameObject.CompareTag("Store"))
        {
            Debug.Log("Store Exit");
            StorePanel.SetActive(false);
            StoreOK.SetActive(false);
            storecheck = false;
        }

        if (other.gameObject.CompareTag("Fishing area"))
        {
            Debug.Log("Fishing area Exit");
            FishingText.SetActive(false);
            Durability.SetActive(false);
        }
    }
}
