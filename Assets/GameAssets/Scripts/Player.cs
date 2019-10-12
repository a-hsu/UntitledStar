﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Transform ship;
    PlayerStatus status;
    PlayerInput input;
    public GameObject targetFar;
    Animator anim;

    public float xySpeed = 18;
    public float lookSpeed = 340f;

    public Vector3 rayDir;

    public Vector3 targetVector;


    // Start is called before the first frame update

    /*
     * 
     * Player Movement
     *      Ship Translation DONE
     *      Ship Rotation DONE
     *      Ship Screen Boundaries DONE
     *      Barrel Roll
     *      Tilt
     *      Uturn
     *      180
     *      Attacks
     *      Bomb
     *      
     * 
     * Camera Movement
     *      Camera Bounds
     *      Camera Lerp
     *      
     * Enemy AI
     *  Movement
     *  Attacks
     *  Spawn/Destroy
     * 
     * Game Physics / Collisions
     * 
     * Inventory/Backpack/PlayerSettings
     * 
     * UI
     * Level Design
     * 
     * Sound Design
     * 
     * VFX
     * 
     * 
     * 
     */

    // Test Section

    public float xSpeed = 0; // Don't touch this
    public float ySpeed = 0; // Don't touch this
    public float maxSpeed = 10f;
    public float xAccel = 10f;
    public float xDecel = 10f;
    public float yAccel = 10f;
    public float yDecel = 10f;



    private void Awake()
    {
        status = new PlayerStatus();
    }
    void Start()
    {
        input = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();

        ship = transform.GetChild(0);
        status.laserType = PlayerStatus.Laser.Single;

    }

    private void Move()
    {
        /*
        float newY = input.y * 12f / 14f;
        targetVector = new Vector3(input.x, input.y, 0);
        Vector3 targetVec = targetVector + transform.position;
        transform.localPosition += targetVector * xySpeed * Time.deltaTime;
        */

        if (input.x < 0 && xSpeed < maxSpeed)
        {
            xSpeed = xSpeed - xAccel * Time.deltaTime;
        }
        else if (input.x > 0 && xSpeed > -maxSpeed)
        {
            xSpeed = xSpeed + xAccel * Time.deltaTime;
        }
        else
        {
            if (xSpeed > (xDecel * Time.deltaTime))
                xSpeed = xSpeed - xDecel * Time.deltaTime;
            else if (xSpeed < -xDecel * Time.deltaTime)
                xSpeed = xSpeed + xDecel * Time.deltaTime;
            else
                xSpeed = 0;
        }
        if (input.y < 0 && ySpeed < maxSpeed)
        {
            ySpeed = ySpeed - yAccel * Time.deltaTime;
        }
        else if (input.y > 0 && ySpeed > -maxSpeed)
        {
            ySpeed = ySpeed + yAccel * Time.deltaTime;
        }
        else
        {
            if (ySpeed > (yDecel * Time.deltaTime))
                ySpeed = ySpeed - yDecel * Time.deltaTime;
            else if (ySpeed < -yDecel * Time.deltaTime)
                ySpeed = ySpeed + yDecel * Time.deltaTime;
            else
                ySpeed = 0;
        }
        xSpeed = Mathf.Clamp(xSpeed, -10, 10);
        ySpeed = Mathf.Clamp(ySpeed, -10, 10);
        transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y + ySpeed * Time.deltaTime, transform.position.z);




        // Camera
        ClampPosition();
    }
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // Check status of player
        CheckStatus();
        // Check Inputs

        // Move player

        // Check Abilities

        // Translate
        rayDir = transform.forward;
        Move();

        // Rotate
        Rotate(input.x, input.y, xySpeed);
        //ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation, Quaternion.Euler(60f * input.x, 60f * input.y, ship.transform.rotation.z), Time.deltaTime);

        HorizontalLean(transform, input.x, 45, .1f);
        // Check if Rolling

        // Check if shooting



        // Animate player


        // Check if hit anything

        // Check if player is hit


        /*
         * Get Input for mouse targetting
         * Rotate Ship to mouse point
         * Lerp ship to mouse point and rotate ship
         * 
         */


    }
    /*
    void Roll()
    {
        float timer = 0f;
        ship.transform.rotation = Quaternion.Lerp(ship.transform.rotation, Quaternion.Euler(0, 0, -90f * 8), 1f);
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0f;
            roll = false;
            rollDirection = 0;
        } 
    }
    */

    // Restricts the player within the camera bounds
    // Creates a vector3 that gets the position of the ship and converts into Viewport space
    // Then, clamps the values of the positions with Clamp01
    // Finally, set the position to a new vector which converts the viewport position into world position
    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngles.x, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, -axis * leanLimit, lerpTime));
    }


    void Rotate(float x, float y, float speed)
    {
        targetFar.transform.parent.position = Vector3.zero;
        targetFar.transform.localPosition = new Vector3(x / 2, y / 1.3f, 1);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(30f * input.y, 30f * input.x, transform.rotation.eulerAngles.z), Mathf.Deg2Rad * lookSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetFar.transform.localPosition), Mathf.Deg2Rad * lookSpeed * Time.deltaTime);

        //            Quaternion.(transform.rotation, Quaternion.LookRotation(targetFar.transform.localPosition), Mathf.Deg2Rad * lookSpeed * Time.deltaTime);
    }


    void CheckStatus()
    {
        if (status.health <= 0)
        {
            Debug.Log("Player is dead");
            status.lives--;
            if (status.lives == 0)
            {
                Debug.Log("Game Over");
            }
        }
        else
        {
            if (status.rings == 3)
            {
                status.lives++;
                status.rings = 0;
            }
        }
    }
}
