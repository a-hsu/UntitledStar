using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRotate : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1.0f);
        transform.eulerAngles += Vector3.Lerp(new Vector3(0,0,-.1f), new Vector3(0, 0, .1f), t);


    }
}
