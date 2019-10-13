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
    float x, y, z = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        x = input.x;
        y = input.y;
        float xRatio = x * xdistance;
        float yRatio = y * ydistance;

        //cam.transform.position = new Vector3(player.transform.position.x * xRatio, player.transform.position.y * yRatio, -15f);

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

    void FixedUpdate()
    {

    }
    void Move()
    {
    }
}
