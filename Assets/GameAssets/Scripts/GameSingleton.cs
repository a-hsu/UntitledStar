using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    /*
     * This script controls the state of the game as well as audio
     */
     
    enum Mode { Corridor, AllRange }  // 0 - Corridor Mode, 1 - All Range Mode
    enum View { ThirdPerson, Cockpit }
    public int level;
    public static AudioSource bgm;
    public static GameSingleton instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ExitGame()
    {
        //Debug.Log("QUIT");
        Application.Quit();
    }
}
