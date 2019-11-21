using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentScr : MonoBehaviour
{
    NavMeshAgent agent = null;
    public GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        this.GetComponent<Renderer>().material.shader= Shader.Find("Legacy Shaders/Transparent/Diffuse");
        this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);        
    }
}
