using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Player player;
    public float dampening = .1f;
    CinemachineVirtualCamera cam;
    public PlayerInput input;
    public float xdistance = 10f;
    public float ydistance = 5f;
    public Vector2 pos = new Vector2(-1, 1);
    float x,y,z = 0f;
    public Vector2 neg = new Vector2(1, -1);

    public float dutch = 6f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        //transform.position = Vector3.Lerp(transform.position, new Vector3 (x*xdistance,y* ydistance, transform.position.z), Time.deltaTime * dampening);
        /*if(input.x < 0)
        {
            float ratio =
            cam.m_Lens.Dutch = Mathf.Lerp(0, ratio, Time.deltaTime);
        }
        if (input.x > 0)
        {
            float ratio =
            cam.m_Lens.Dutch = Mathf.Lerp(0, ratio, Time.deltaTime);
        }*/
    }
    public Transform cameraTarget;
    public float sSpeed = 20.0f;
    public Vector3 dist;
    public Transform lookTarget;

    void FixedUpdate()
    {
        Vector3 dPos = cameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }
    void Move()
    {
        x = input.x;
        y = input.y;
    }
}
