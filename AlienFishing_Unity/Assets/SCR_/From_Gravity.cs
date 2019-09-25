using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class From_Gravity : MonoBehaviour
{
    public float gravity = -10;
    public Vector3 gravityUP;
    //이전 위치와 현재 위치가 다를시에만 중력이 작용되게;

    public Vector3 Attract(Transform body, Vector3 aft_pos)
    {
        Vector3 target_int_vec = new Vector3(Mathf.Round(body.position.x*10)*0.1f, Mathf.Round(body.position.y*10)*0.1f, Mathf.Round(body.position.z*10)*0.1f);

        gravityUP = (body.position - transform.position).normalized;
        Vector3 bodyUP = body.up;

        if (target_int_vec != aft_pos)
        {
            body.GetComponent<Rigidbody>().AddForce(gravityUP * gravity);
            aft_pos = target_int_vec;            
        }
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUP, gravityUP) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);

        return aft_pos;
    }
}
