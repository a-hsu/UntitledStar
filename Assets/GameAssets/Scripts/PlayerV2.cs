using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour
{

    private Transform ship;

    
    /*
     * Ship Movement Constraints
     * 
         * When the player moves the joystick, the ship gains acceleration and rotates
         * The reticle is in line with the ship
         * Ship rotation happens on all 3 axis, yaw, roll, and pitch
         * The ship ALWAYS rotates on the z axis slowly for several degrees, even while turning
         * The ship always decelerates, rotates, and then accelerates
         * When no input is given, the ship will always rotate back towards the direction of the dolly
         * 
         *
     * 
     * Camera Movement Constraints
        * When the player moves, the camera will rotate on all three axis, as well as translate
        * 
     */

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

    float xSpeed = 0; // Don't touch this
    float ySpeed = 0; // Don't touch this
    public float maxSpeed = 10f;
    public float xAccel = 10f;
    public float xDecel = 10f;
    public float yAccel = 10f;
    public float yDecel = 10f;

    public float idleRotateSpeed = 2f;

    public float tiltSpeed = 2f;



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
        /*
        Vector3 oldPos = transform.position;

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

        Vector3 newPos = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y + ySpeed * Time.deltaTime, transform.position.z);

        if (oldPos.x == newPos.x)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + ySpeed * Time.deltaTime, transform.position.z);

        }
        else if (oldPos.y == newPos.y)
        {
            transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        }
        else
        {
            transform.position = new Vector3(transform.position.x + xSpeed * Time.deltaTime, transform.position.y + ySpeed * Time.deltaTime, transform.position.z);

        }

        */
        // Camera

        Translate();
        Pitch();
        Yaw();
        Roll();
        if(input.x == 0 && input.y == 0)
        {
            ReturnAxis();
        }
        ClampPosition();
    }
    void ReturnAxis()
    {
        // Get the vector of the direction of the dolly
        GameObject dolly;
        //transform.rotation = Quaternion.Lerp(transform.rotation, dolly.transform.rotation, Time.deltaTime * 1)
    }
    float speed = 5f;
    float zSpeed = 1f;
    float translateTime;
    float rotateTime;
    void Boost()
    {
        zSpeed = 10f;
    }
    void Brake()
    {
        zSpeed = 2f;
    }
    void Translate()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(speed * input.x, speed * input.y, zSpeed), Time.deltaTime * translateTime);
    }
    void Pitch()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x,45f, transform.rotation.eulerAngles.z) , Time.deltaTime * rotateTime);
    }
    void Yaw()
    {

    }
    void Roll()
    {

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

        //if (input.tilt != 0)
        // Tilt(input.tilt, tiltSpeed);

        // Rotate
        Rotate(input.x, input.y, lookSpeed, .1f);
        //IdleRotation(idleRotateSpeed);
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
        if (pos.x == 0 || pos.x == 1)
        {
            xSpeed = 0f;
        }
        if (pos.y == 0 || pos.y == 1)
        {
            ySpeed = 0f;
        }
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void IdleRotation(float speed)
    {
        float sinValue = Mathf.Sin(speed * Time.time);
        Vector3 newAngles = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + sinValue * Mathf.Rad2Deg);

        transform.rotation = Quaternion.Euler(newAngles);


        //Quaternion.Euler(new Vector3(0, 0, sinValue * .1f * Mathf.Rad2Deg));
    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngles.x, targetEulerAngles.y, Mathf.LerpAngle(targetEulerAngles.z, -axis * leanLimit, lerpTime));
    }


    void Rotate(float x, float y, float speed, float t)
    {
        targetFar.transform.parent.position = Vector3.zero;
        targetFar.transform.localPosition = new Vector3(x, y, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetFar.transform.localPosition), Mathf.Deg2Rad * speed * Time.deltaTime);
    }

    void Tilt(int direction, float tiltSpeed)
    {
        float fullTilt = 90f * (float)direction;

        float remainingTilt = transform.eulerAngles.z - fullTilt;
        Debug.Log("direction: " + direction);
        Quaternion newQuat = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 90 * direction);
        float angle = Mathf.LerpAngle(0, 90, Time.deltaTime * tiltSpeed);
        /*if (direction != 0)
        {
            if (direction == -1)
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);
            else
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -angle);
        }*/


        //   transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90f * direction), Time.deltaTime);
        //          transform.rotation = Quaternion.Lerp(transform.rotation, newQuat, tiltSpeed);
        //
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


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    PlayerInput input;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(input.x, input.y, 0);
        Vector3 finalDir = new Vector3(input.x, input.y, 10.0f);
        transform.position += dir * speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDir), Mathf.Deg2Rad * 50f);
    }
}*/
