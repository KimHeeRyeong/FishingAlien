using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaitController : MonoBehaviour
{
    public enum BaitState
    {
        MOVE_TO_GROUND,
        MOVE_AROUND,
        COL_ENEMY,
        CASTING
    }

    [SerializeField] FishingCable fisingCable;
    [SerializeField] Transform camTransform;
    [SerializeField] float walkSpeed = 1.0f;
    [SerializeField] float turnSpeed = 400.0f;
    [SerializeField] string UIDCODE;

    public LayerMask mask;
    BaitState state = new BaitState();
    Animator anim;
    Rigidbody rd;
    [SerializeField]GameObject fade;
    Image fadeImage;
    float freezeY = 0;
    #region public
    public string GetUIDCODE()
    {
        return UIDCODE;
    }
    public BaitState GetState()
    {
        return state;
    }
    public void SetState(BaitState state)
    {
        this.state = state;
    }
    #endregion
    void Awake()
    {
        Physics.gravity = Vector3.up * -9.8f;
        state = BaitState.MOVE_TO_GROUND;
        anim = GetComponent<Animator>();
        rd = GetComponent<Rigidbody>();
        
        fadeImage = fade.GetComponent<Image>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (state == BaitState.MOVE_AROUND)
            {
                sound_single.Instance.PlayFishingUP();
                state = BaitState.CASTING;
                fisingCable.SetBaitBind(false);

                StartCoroutine(FadeOut());
                StartCoroutine(Next());
            }

        }
        switch (state)
        {
            case BaitState.COL_ENEMY:
                break;
            case BaitState.CASTING:
                break;
        }
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(2);

        GameSingleton.Instance.SetUIState(GameSingleton.UIState.NONE);
        sound_single.Instance.AllStop();
        SceneManager.LoadScene(1);
    }
    void FixedUpdate()
    {
        if (state != BaitState.MOVE_AROUND)
        {
            return;
        }

        if (transform.position.y > freezeY + 0.1f || transform.position.y < freezeY - 0.1f)
            transform.position = new Vector3(transform.position.x, freezeY, transform.position.z);

        Debug.Log("move");

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor != 0 || ver != 0)
        {
            Walk();

            //rotate bait move dir
            Vector3 forward = Vector3.ProjectOnPlane(camTransform.forward, Vector3.up);
            Vector3 rotForward = (camTransform.right * hor + forward * ver).normalized;
            float angle = Vector3.SignedAngle(transform.forward, rotForward, Vector3.up);
            Quaternion target2 = Quaternion.AngleAxis(angle, Vector3.up) * transform.rotation;

            if (angle > 3 || angle < -3)
                transform.rotation = Quaternion.Slerp(transform.rotation, target2, Time.deltaTime * 10);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit raycastHit;
            if (!Physics.Raycast(ray, out raycastHit, 3, mask))
                transform.position += transform.forward * walkSpeed * Time.deltaTime;

            //bait move
            transform.position += transform.forward * Time.deltaTime * walkSpeed;
        }
        else
            Idle();

        //if (Input.GetKey("w"))
        //    Walk(Input.GetAxis("Vertical"), 0);
        //else if (Input.GetKey("s"))
        //    Walk(-Input.GetAxis("Vertical"), 180);
        //else if (Input.GetKey("d"))
        //    Walk(Input.GetAxis("Horizontal"), 90);
        //else if (Input.GetKey("a"))
        //    Walk(-Input.GetAxis("Horizontal"), -90);
        //else
        //    Idle();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (state == BaitState.MOVE_TO_GROUND)
            {
                rd.constraints = rd.constraints | RigidbodyConstraints.FreezePositionY;
                freezeY = transform.position.y;
                state = BaitState.MOVE_AROUND;
            }
        }
    }
    
    #region move animation
    void Walk()
    {
        if (!anim.GetBool("Walk"))
            anim.SetBool("Walk", true);
    }
    void Walk(float axis, float rotate)
    {
        Quaternion target = Quaternion.Euler(0, camTransform.rotation.eulerAngles.y + rotate, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * turnSpeed);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycastHit;
        if (!Physics.Raycast(ray, out raycastHit, 3, mask))
            transform.position += transform.forward * axis * walkSpeed * Time.deltaTime;

        if (!anim.GetBool("Walk"))
            anim.SetBool("Walk", true);
    }
    void Idle()
    {
        if (anim.GetBool("Walk"))
            anim.SetBool("Walk", false);
    }
    #endregion
    IEnumerator FadeOut()
    {
        Color alp = fadeImage.color;
        alp.a = 0f;
        fadeImage.color = alp;
        fade.SetActive(true);
        while (alp.a < 1f)
        {
            alp.a += Time.deltaTime * 1.5f;
            fadeImage.color = alp;
            yield return Time.deltaTime;
        }
        yield return null;
    }
}