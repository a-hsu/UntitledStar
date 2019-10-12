using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public float movementSpeed = 50f;
    public float turnSpeed = 60f;
    public float forwardSpeed = 2f;
    Transform myT;

    private void Awake()
    {
        myT = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {

    }
    private void FixedUpdate()
    {
        Thrust();
        Turn();
    }
    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        
            myT.Rotate(0, yaw, 0f);
    }
    void Thrust() {
        if (Input.GetAxis("Horizontal") != 0)
            myT.position += myT.forward * movementSpeed * Time.deltaTime * Mathf.Abs(Input.GetAxis("Horizontal"));
        else
            myT.position += myT.forward * Time.deltaTime * forwardSpeed;
    }

}
