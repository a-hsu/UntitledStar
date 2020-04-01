using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public float speed;
    public float checkDistance = 60f;

    [SerializeField]
    public List<LegStepper> legs;


    private void Start()
    {
        Physics.IgnoreLayerCollision(9, 9);
    }

    private void Update()
    {
        int count = 0;
        foreach (LegStepper leg in legs)
        {
            if (leg.isMoving)
            {
                count += 1;
            }
        }

        Vector3 newZNormal = GetPointOfContactNormal();
        if (Vector3.Angle(transform.up, newZNormal) > 10f)
        {
            //transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
            //Quaternion rot = Quaternion.LookRotation(Vector3.Cross(transform.right, newZNormal), transform.up);
            //rot = Quaternion.Slerp(transform.rotation, rot, 0.1f*  Time.deltaTime);
            //transform.rotation = rot;
            transform.Rotate(transform.forward, Vector3.SignedAngle(transform.up, newZNormal, transform.up) * 0.1f * Time.deltaTime);
        }

        //Get centroid of leg positions. Note: This can result in a centroid outside of the polygon made by the 4 legs but fuck it for now
        Vector3 legCentroid = new Vector3(legs[0].transform.position.x + legs[1].transform.position.x + legs[2].transform.position.x + legs[3].transform.position.x
                                          , legs[0].transform.position.y + legs[1].transform.position.y + legs[2].transform.position.y + legs[3].transform.position.y
                                          , legs[0].transform.position.z + legs[1].transform.position.z + legs[2].transform.position.z + legs[3].transform.position.z) * 0.25f;

        //Bias body centering towards forward legs
        transform.position = Vector3.Lerp(transform.position, legCentroid + transform.right *10f, speed * Time.deltaTime); 
    }

    private Vector3 GetPointOfContactNormal()
    {
        Vector3 QR = legs[1].transform.position - legs[0].transform.position;
        Vector3 QS = legs[2].transform.position - legs[0].transform.position;

        return Vector3.Cross(QR, QS);
    }


    public Vector3 SetValidPosition()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, -transform.up * checkDistance, Color.red, 1f);
        Debug.DrawRay(transform.position, transform.up * checkDistance, Color.red, 1f);
        Debug.DrawRay(transform.position, transform.right, Color.red, 1f);
        Debug.DrawRay(transform.position, -transform.right , Color.red, 1f);


        Debug.DrawRay(transform.position, Vector3.Normalize(-transform.up + transform.forward*2) * checkDistance, Color.green, 1f);

        //note: leg bone transforms will always have weird original rotations so this is one of them
        //if (Physics.Raycast(transform.position, Vector3.Normalize(-transform.up + transform.forward), out hit, checkDistance))
        //{
        //    return hit.point + Vector3.Normalize(transform.up - transform.forward) * 10f;
        //}
        if (Physics.Raycast(transform.position, -transform.up, out hit, checkDistance))
        {
            return hit.point + transform.up * 25f + transform.up * Mathf.Sin(Time.time);
        }
        else if (Physics.Raycast(transform.position, transform.right, out hit, checkDistance))
        {
            return hit.point - transform.up * 25f + transform.up * Mathf.Sin(Time.time);
        }
        else if (Physics.Raycast(transform.position, -transform.right, out hit, checkDistance))
        {
            return hit.point - transform.up * 25f + transform.up * Mathf.Sin(Time.time);
        }
        else
        {
            return transform.position;
        }
    }
}
