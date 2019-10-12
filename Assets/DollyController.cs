using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyController : MonoBehaviour
{
    public float turnSpeed = 1f;
    public float movementSpeed = 1f;
    public float forwardSpeed = 1f;
    public Transform myT;
    GameSingleton gameManager;
    public Transform target;
    private void Awake()
    {
        myT = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //if(gameManager.mode == GameSingleton.Mode.Corridor)
        //    transform.Translate(transform.forward * forwardSpeed);
        //else
        //{

        //
        //target.rotation = myT.rotation;
        Thrust();
        Turn();
    }
    
    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        
        myT.Rotate(0, yaw, 0f);
    }
    void Thrust()
    {
        if (Input.GetAxis("Horizontal") != 0)
            myT.position += myT.forward * movementSpeed * Time.deltaTime * Mathf.Abs(Input.GetAxis("Horizontal"));
        else
            myT.position += myT.forward * Time.deltaTime * forwardSpeed;

    }
}
