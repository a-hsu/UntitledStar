using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * forwardSpeed);
    }
}
