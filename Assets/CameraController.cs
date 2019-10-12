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
    float x,y = 0f;
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
        if (player.transform.position.x < 0)
            x = -player.transform.position.x / 14f;
        else
            x = player.transform.position.x / 14f;
        if (player.transform.position.y < 0)
            y = -player.transform.position.y / 6f;
        else
            y = player.transform.position.y / 14f;
        
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
}
