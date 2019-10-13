using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public enum Type { Enemy, Boss}
    public Type type;

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
