using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDestruction : MonoBehaviour
{
    public bool bothChainsBroken = false;
    public List<Rigidbody> ground_debris;
    public List<Enemy> Chains;
    public Transform AxeCutscene;
    public Transform playerCamera;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Start cutscene when chains have no health
        if (Chains[0].health <= 0 && Chains[1].health <= 0 && counter < 1)
        {
            counter += 1;
            breakChains();
            StartCoroutine(SetNotKinematic());
            AxeCutscene.gameObject.SetActive(true);
            playerCamera.gameObject.SetActive(false);
            StartCoroutine(EndCutScene());
        }

    }

    public IEnumerator EndCutScene()
    {
        yield return new WaitForSecondsRealtime(16f);
        AxeCutscene.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void breakChains()
    {
        foreach(Enemy chain in Chains)
        {
            foreach(Transform child in chain.transform)
            {
                child.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    public IEnumerator SetNotKinematic()
    {
        Debug.Log("Gothere");
        yield return new WaitForSecondsRealtime(5f);
        GetComponent<Rigidbody>().isKinematic = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 15)
        {
            Debug.Log(collision.gameObject.name);
            foreach(Rigidbody rb in ground_debris)
            {
                rb.isKinematic = false;
            }
        }
    }


}
