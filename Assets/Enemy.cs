using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
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
