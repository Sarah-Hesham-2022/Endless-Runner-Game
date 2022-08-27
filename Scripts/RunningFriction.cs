using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningFriction : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    { 
        ps.transform.position = GameObject.Find("Player").transform.position;

        if(GameObject.Find("Player").transform.position.y >= 1f || ps.transform.position.z==0)
        {
            ps.transform.position = new Vector3(0, 0, -50);
        }
    }
}
