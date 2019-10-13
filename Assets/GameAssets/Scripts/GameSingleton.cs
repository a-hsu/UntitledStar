using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSingleton : MonoBehaviour
{

    /*
     * This script controls the state of the game as well as audio
     */
     
    public enum Mode { Corridor, AllRange }  // 0 - Corridor Mode, 1 - All Range Mode
    public enum View { ThirdPerson, Cockpit }
    public enum GameState { CutScene, InGame, Death, Victory}
    public GameState state;
    public Mode mode;
    public View view;

    public int level;
    public Vector3[] startPosition;
    public static AudioSource bgm;
    public static GameSingleton instance;
    public bool isPersistant;
    public bool isPaused = false;
    public Player player;
    PlayerStatus playerStatus;

    public float gameTimer;
    public Enemy boss;
    public GameObject leftChainHitBox;
    public GameObject rightChainHitBox;
    //public GameObject axeHitBox;

    public void reloadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Init()
    {

        Instantiate(player, startPosition[level], Quaternion.Euler(0, 0, 0));
    }

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
        gameTimer = 0;
        //leftChainHitBox.GetComponent<MeshCollider>().enabled = false;
        //rightChainHitBox.GetComponent<MeshCollider>().enabled = false;
        
       // axeHitBox.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Intro" || scene.name == "Outro")
        {
            state = GameState.CutScene;
        } //else if(playerStatus.health <= 0)
          //{
          //     state = GameState.Death;
          // } 
        else
        {
            state = GameState.InGame;
        }
    }
    // Update is called once per frame
    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
    void Update()
    {
        gameTimer += Time.deltaTime;
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            if (isPaused)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }

        switch (state)
        {
            case GameState.CutScene:
                break;
            case GameState.InGame:
                if(gameTimer > 20f || boss.health < (boss.maxHealth * .8f) || Input.GetKeyDown(KeyCode.U))
                {
                    Debug.Log(Input.GetKeyDown(KeyCode.U));
                    //leftChainHitBox.GetComponent<Enemy>().Init(2500, Enemy.Type.Enemy);
                    //rightChainHitBox.GetComponent<Enemy>().Init(2500, Enemy.Type.Enemy);
                }
                break;
            case GameState.Death:

                break;
            case GameState.Victory:
                break;
            default:
                break;  

        }
    }
    void ExitGame()
    {
        //Debug.Log("QUIT");
        Application.Quit();
    }
}
