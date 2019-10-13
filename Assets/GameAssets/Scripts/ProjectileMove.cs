using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed = 20f;
    public float fireRate = 4f;
    public float lifeTime = 2f;
    Transform parent;
    Transform newPos;
    Player go;
    Transform oldPos;
    Vector3 dir;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        go = FindObjectOfType<Player>();
        
        dir = go.rayDir;

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        if(speed != 0)
        {
            transform.position +=  dir * speed * Time.deltaTime;
        } else
        {
            Debug.Log("No Speed");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Surface")
        {
            speed = 0;
            Destroy(gameObject);
        }
    }
}
