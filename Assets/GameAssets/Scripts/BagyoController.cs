using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BagyoController : MonoBehaviour
{


    CinemachineVirtualCamera cam;
    public float amplitude = 2f;
    public float frequency = 2f;
    public float timerAmp = 0f;
    public float timerFreq = 0f;
    public float timeScaler = .2f;
    public float playTime = 5f;
    public NoiseSettings myNoiseProfile;
    public NoiseSettings myNoiseProfileTwo;
    public GameSingleton gamemanager;

    public AudioManager audio;
    public AudioClip engine;
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        playTime -= Time.deltaTime;

        if(playTime >= 45f)
        {
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = myNoiseProfile;
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = .5f;
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = .5f;
        }
        else if (playTime <= 35)
        {
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = myNoiseProfile;

            GoAway();
        }
        else
        {
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = myNoiseProfileTwo;
            Approach();
            audio.EffectsSource.volume = Mathf.SmoothStep(0,.2f, Time.deltaTime);


            audio.PlayOnce(engine);
        }
        if(playTime <= 30)
        {
            gamemanager.NextScene();
            gamemanager.state = GameSingleton.GameState.InGame;
        }
    }
    void GoAway()
    {
        timerAmp -= Time.deltaTime * timeScaler;
        timerFreq -= Time.deltaTime * timeScaler;
        if (timerAmp < 0f)
            timerAmp = 0;
        if (timerFreq < 0f)
            timerFreq = 0f;
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.SmoothStep(frequency, 1, timerFreq);
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = Mathf.SmoothStep(frequency, 1, timerFreq);
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = myNoiseProfile;
    }
    void Approach()
    {
        timerAmp += Time.deltaTime * timeScaler;
        timerFreq += Time.deltaTime * timeScaler;
        if (timerAmp > 1f)
            timerAmp = 1;
        if (timerFreq > 1f)
            timerFreq = 1f;
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.SmoothStep(0, amplitude, timerAmp);
        cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = Mathf.SmoothStep(0, frequency, timerFreq);
    }
}
