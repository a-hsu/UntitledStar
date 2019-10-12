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
    Animator anim;
    public int tilt = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && Input.GetButton("Fire1"))
        {
            bigShot = true;
        }
        else
        {
            bigShot = false;
            timer = .5f;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
            bigShot = false;
            timer = .5f;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            bombShot = true;
        }
        bombShot = false;

        if (Input.GetButton("LeftTilt"))
        {
            tilt = -1;
        }else if (Input.GetButton("RightTilt"))
        {
            tilt = 1;
        } else
        {
            tilt = 0;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

    }
}
