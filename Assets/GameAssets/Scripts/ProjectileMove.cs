using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] public Transform target;
    [Range(0f,2f)]public float speed = 1f;
    public float fireRate = 4f;
    public float lifeTime = 2f;
    
    public LaserSpawn go;

    Vector3 dir;
    public Rigidbody rb;

    void Start()
    {
        go = FindObjectOfType<LaserSpawn>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(HomingMissile());
    }



    private IEnumerator HomingMissile()
    {
        transform.parent = null;
        speed = 0;
        while (target != null)
        {
            Vector3 relativePos = target.position - transform.position - target.forward;  //Aiming at a point just behind the target so it always hits the target if coming fron the front, but never from behind
            Quaternion rotation = Quaternion.LookRotation(Vector3.Scale(new Vector3(0.5f, 0.5f, 0.5f), relativePos + target.forward * 3));  //
            rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            transform.rotation = rotation;

            speed = Mathf.Lerp(speed, 2f, 0.05f * Time.deltaTime);

            transform.Translate(relativePos * speed * Time.deltaTime);
            yield return null;
        }
    }


    // Update is called once per frame
    void Update()
    {

        //lifeTime -= Time.deltaTime;
        //if(lifeTime <= 0)
        //{
        //    Destroy(gameObject);
        //}
        //if(speed != 0)
        //{
        //   // rb.AddForce(transform.forward * force);
        //    //transform.position +=  dir * speed * Time.deltaTime;
        //} else
        //{
        //    Debug.Log("No Speed");
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water" /*|| other.gameObject.tag == "Enemy" */|| other.gameObject.tag == "Surface" || other.gameObject.tag == "Player")
        {
            speed = 0;
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(100);
            } else if(other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(10);
            } 
            Destroy(gameObject);
        }
    }
}
