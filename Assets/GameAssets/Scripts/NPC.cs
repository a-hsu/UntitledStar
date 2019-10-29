using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public float health;
    public float speed;
    public float angularSpeed;
    public float knockbackPower = 10f;
    public bool canMove = true;
    public bool isKnockedBack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isKnockedBack)
            transform.position += transform.forward * .1f;
        else
            GetComponent<Rigidbody>().AddExplosionForce(500f, transform.position, 300f);

    }
    IEnumerator Knockback(Vector3 dir)
    {
        isKnockedBack = true;
        canMove = false;
        print(canMove);

       //GetComponent<Rigidbody>().AddExplosionForce(500f, transform.position, 300f);
        //transform.position = Vector3.Lerp(transform.position, dir, Time.deltaTime);

        yield return new WaitForSeconds(3f);
        print("knockedback");
        print(dir);
        canMove = true;
        print(canMove);
        isKnockedBack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && isKnockedBack == false)
        {
            print("Collision: " + collision.gameObject.name);
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            // Get the XY vector directly away from the player
            Vector3 newDirection = new Vector3(direction.x, direction.y, -direction.z);

            StartCoroutine(Knockback(direction));
        }
    }
}
