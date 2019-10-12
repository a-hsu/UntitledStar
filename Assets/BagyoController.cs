using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BagyoController : MonoBehaviour
{


    CinemachineVirtualCamera cam;
    public float amplitude = 2f;
    public float frequency = 2f;

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {

        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.Lerp(0, amplitude, Time.deltaTime);
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = Mathf.Lerp(0, frequency, Time.deltaTime);
    }
}
