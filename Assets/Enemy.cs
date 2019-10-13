using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public enum Type { Enemy, Boss, Chain}
    public Type type;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(float maxHealth, Type enemyType)
    {
        gameObject.SetActive(true);

        gameObject.GetComponent<MeshCollider>().enabled = true;
        health = maxHealth;
        type = enemyType;
    }
    // Update is called once per frame
    void Update()
    {
        CheckStatus();
        if(gameObject.name == "MechParent")
        {
          //  gameObject.GetComponent<BoxCollider>().center = 
        }
        if (type == Type.Boss)
        {
            if (health > 0)
                image.transform.localScale = new Vector3(health / maxHealth, 1, 1);
            else
            {
                image.transform.localScale = new Vector3(0, 1, 1);
            }
        }
        if(type == Type.Chain)
        {
            StartCoroutine(BreakChains());
        }
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
            if(type != Type.Boss)
                StartCoroutine(BreakChains());
            Destroy(gameObject);
        }
    }
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
    }
    void Die()
    {
        // Get shit on
        GetComponent<Collider>().enabled = false;

        StartCoroutine(Explode());


        Debug.Log("Dead");
    }
}
