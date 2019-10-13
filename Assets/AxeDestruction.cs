using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDestruction : MonoBehaviour
{
    public bool bothChainsBroken = false;
    public List<Rigidbody> ground_debris;
    public Vector3 axePosition = new Vector3(0f, 227f, 176.6f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bothChainsBroken = true)
            StartCoroutine(DestroyArena());
    }

    public IEnumerator DestroyArena()
    {
        while (Vector3.Distance(transform.position, axePosition) > 5)
        {
            Vector3 slerp = Vector3.Lerp(transform.position, axePosition, Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(slerp);
            transform.rotation *= Quaternion.Euler(0f, 1f, 0f);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 15)
        {
            foreach(Rigidbody rb in ground_debris)
            {
                rb.isKinematic = false;
            }
        }
    }


}
