using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] public Transform target;
    [Range(20f, 100f)] public float missileSpeed = 20f;
    public float fireRate = 4f;
    public float lifeTime = 10f;

    public Transform explosion;


    public LaserSpawn go;

    Vector3 dir;
    public Rigidbody rb;

    void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<Player>().gameObject.transform;
        }
        go = FindObjectOfType<LaserSpawn>();
        rb = GetComponent<Rigidbody>();
        transform.parent = null;
        StartCoroutine(InactiveTime());
        StartCoroutine(HomingMissile());
    }

    private IEnumerator InactiveTime()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSecondsRealtime(3f);
        GetComponent<Collider>().enabled = true;
    }



    private IEnumerator HomingMissile()
    {
        float time = lifeTime;

        while (target != null)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                explosion.transform.parent = null;
                explosion.gameObject.SetActive(true);
                Destroy(gameObject);
            }
            Vector3 relativePos = target.position - transform.position + target.forward * Random.Range(-10, 10f) + target.right * Random.Range(-10, 10f);  //Aiming at a point just behind the target so it always hits the target if coming fron the front, but never from behind
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);  //
            rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            transform.rotation = rotation;

            missileSpeed = Mathf.Lerp(missileSpeed, 100f, 0.5f * Time.deltaTime);
            transform.Translate(transform.forward * missileSpeed * Time.deltaTime);
            //transform.Translate(relativePos * missileSpeed * Time.deltaTime);
            yield return null;
        }
    }


  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Surface" || other.gameObject.tag == "Player")
        {
            missileSpeed = 0;
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(100);
            }
            else if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(10);
            }
            
            explosion.transform.parent = null;
            explosion.gameObject.SetActive(true);

            Destroy(gameObject);
        }
    }
}

