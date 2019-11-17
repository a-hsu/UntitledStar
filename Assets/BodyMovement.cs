using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
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

        Vector3 newPosition = SetValidPosition();
        if (newPosition != transform.position)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
        }
    }



    public Vector3 SetValidPosition()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, -transform.up * 100f, Color.red, 3f);
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
        else
        {
            return transform.position;
        }
    }
}
