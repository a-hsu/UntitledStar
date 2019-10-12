using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechTranslation : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public Transform Player;
    public Transform Ground;

    public bool hitAreaBounds = false;

    [Range(0f, 0.2f)] [SerializeField] public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitAreaBounds)
        {
            Vector3 slerp = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z), speed * Time.deltaTime);
            m_Rigidbody.MovePosition(slerp);
        }
        else
        {
            StartCoroutine(MoveToCenterArena());
        }       

    }

    private IEnumerator MoveToCenterArena()
    {
        while (Vector3.Distance(transform.position, Ground.position) > 100f)
        {
            Vector3 slerp = Vector3.Lerp(transform.position, new Vector3(Ground.transform.position.x, transform.position.y, Ground.transform.position.z), speed * Time.deltaTime);
            m_Rigidbody.MovePosition(slerp);
            yield return null;
        }
        hitAreaBounds = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.name == "ArenaBounds")
        {
            hitAreaBounds = true;
        }
    }
}
