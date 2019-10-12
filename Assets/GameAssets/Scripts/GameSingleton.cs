using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{

    /*
     * This script controls the state of the game as well as audio
     */
     
    public enum Mode { Corridor, AllRange }  // 0 - Corridor Mode, 1 - All Range Mode
    public enum View { ThirdPerson, Cockpit }
    public Mode mode;
    public View view;
    public int level;
    public static AudioSource bgm;
    public static GameSingleton instance;
    public bool isPersistant;

    public bool isPaused = false;

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this); // or gameObject
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            if (isPaused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
    void ExitGame()
    {
        //Debug.Log("QUIT");
        Application.Quit();
    }
}
