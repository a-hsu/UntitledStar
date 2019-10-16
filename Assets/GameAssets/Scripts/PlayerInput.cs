using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float x, y;
    public Vector3 mousePos;
    public bool isShooting;
    public bool bigShot;
    public bool bombShot;
    public float timer = 0.5f;
    public int tilt = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // Get Input

        // Basic Movement
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        //mousePos = Input.mousePosition;

        // Shoot

        // Basic shot

        // For now, holding down the fire button continues to shoot
        if (Input.GetButton("Fire1"))
        {
            isShooting = true;
        }

        // Boost

        // Break

        // U-Turn

        // Tilt
        if (Input.GetButton("LeftTilt"))
        {
            tilt = -1;
        }
        else if (Input.GetButton("RightTilt"))
        {
            tilt = 1;
        }
        else
        {
            tilt = 0;
        }

        // Barrel Roll




       


    }
}
