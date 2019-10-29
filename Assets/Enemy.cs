using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : NPC
{

    // [Header("Flags")]
    public enum Movement { Stationary, Moving }
    public Movement movement;
    public enum MovementType { Procedural, NonProcedural }
    public MovementType moveType;
    public enum MovementAggression { None, Average, Hyper }
    public MovementAggression mveAgg;

    public enum AttackPattern { None, Procedural, NonProcedural }
    public AttackPattern attackPattern;

    List<Attack> attacks = new List<Attack>();

    public enum EnemyType { Enemy, Boss, Chain }
    public EnemyType enemyType;

    // public Image image;

    public class Attack {
        public float damage;
        public bool isMoving;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(float maxHealth, EnemyType newEnemyType)
    {
        gameObject.SetActive(true);

        gameObject.GetComponent<MeshCollider>().enabled = true;
        health = maxHealth;
        enemyType = newEnemyType;
    }
    // Update is called once per frame
    void Update()
    {
        CheckStatus();
        if(gameObject.name == "MechParent")
        {
          //  gameObject.GetComponent<BoxCollider>().center = 
        }
        /*
        if (type == Type.Boss)
        {
            if (health > 0)
                image.transform.localScale = new Vector3(health / maxHealth, 1, 1);
            else
            {
                image.transform.localScale = new Vector3(0, 1, 1);
            }
        }*/
    //    if(type == Type.Chain)
     //   {
     //       StartCoroutine(BreakChains());
     //   }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log("Hit");

    }

    void CheckStatus()
    {
        if (health <= 0)
        {
            Die();

        }
    }

    public GameObject explosion;
    private IEnumerator Explode()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(explosion, transform.position, transform.rotation);
            //if(type != Type.Boss)
            //    StartCoroutine(BreakChains());
            Destroy(gameObject);
        }
    }
    /*
    private IEnumerator BreakChains()
    {
        while (true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            for(int c = 0; c < transform.childCount; c++)
            {
                transform.GetChild(c).gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.GetChild(c).gameObject.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(-1,1), transform.position, Random.Range(0, 3));
            }
            yield return new WaitForSeconds(10f);
            
            Destroy(gameObject);

        }
    }*/
    void Die()
    {
        // Get shit on
        GetComponent<Collider>().enabled = false;

        StartCoroutine(Explode());


        Debug.Log("Dead");
    }
}
