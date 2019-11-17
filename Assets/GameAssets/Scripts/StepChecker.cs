using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepChecker : MonoBehaviour
{
    private float checkDistance = 60f;
    public Transform leg;
    public Vector3 originalLocalPosition;
    List<Vector3> raycastHits = new List<Vector3>();
    

    private void Start()
    {
        Physics.IgnoreLayerCollision(9, 9);
        originalLocalPosition = leg.localPosition;
    }

    public Vector3 SetNextStepPosition()
    {
        
   

        Vector3 newPosition = Vector3.zero;

        Debug.DrawRay(transform.position, -transform.up * checkDistance, Color.red, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(-transform.up + transform.forward) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(-transform.up - transform.forward) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(-transform.up + transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(-transform.up - transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(-transform.up + transform.forward + transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(-transform.up + transform.forward - transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(-transform.up - transform.forward + transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(-transform.up - transform.forward - transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, transform.up * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(transform.up + transform.forward) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(transform.up - transform.forward) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(transform.up + transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(transform.up - transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(transform.up + transform.forward + transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(transform.up + transform.forward - transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(transform.up - transform.forward + transform.right) * (checkDistance + 25f), Color.green, 1f);
        Debug.DrawRay(transform.position, Vector3.Normalize(transform.up - transform.forward - transform.right) * (checkDistance + 25f), Color.green, 1f);
        //note: leg bone transforms will always have weird original rotations so this is one of them
        //if (Physics.Raycast(transform.position, -transform.up + transform.forward, out hit, checkDistance))
        //{
        //    return hit.point;
        //}
        //else if (Physics.Raycast(transform.position, -transform.up, out hit, checkDistance + 25f))
        //{
        //    return hit.point;
        //}
        //else
        //{
        //    leg.transform.localPosition = originalLocalPosition;
        //    return leg.transform.position;
        //}
        RaycastHit hit;

        //down
        if (Physics.Raycast(transform.position, -transform.up, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //forward + down
        if(Physics.Raycast(transform.position, -transform.up + transform.forward, out hit , checkDistance))
            raycastHits.Add(hit.point);

        //backward + down
        if (Physics.Raycast(transform.position, -transform.up - transform.forward, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //right + down
        if (Physics.Raycast(transform.position, -transform.up + transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //left + down
        if (Physics.Raycast(transform.position, -transform.up - transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //foward + right + down
        if (Physics.Raycast(transform.position, -transform.up + transform.forward + transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //forward + left + down
        if (Physics.Raycast(transform.position, -transform.up + transform.forward - transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //backward + right + down
        if (Physics.Raycast(transform.position, -transform.up - transform.forward + transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //backward + left + down
        if (Physics.Raycast(transform.position, -transform.up - transform.forward - transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //up
        if (Physics.Raycast(transform.position, transform.up, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //forward + up
        if (Physics.Raycast(transform.position, transform.up + transform.forward, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //backward + up
        if (Physics.Raycast(transform.position, transform.up - transform.forward, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //right + up
        if (Physics.Raycast(transform.position, transform.up + transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //left + up
        if (Physics.Raycast(transform.position, transform.up - transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //forward + right + up
        if (Physics.Raycast(transform.position, transform.up + transform.forward + transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //forward + left + up
        if (Physics.Raycast(transform.position, transform.up + transform.forward - transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //backward + right + up
        if (Physics.Raycast(transform.position, transform.up - transform.forward + transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //backward + left + up
        if (Physics.Raycast(transform.position, transform.up - transform.forward - transform.right, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);


        int furthestPointIndex = 0;
        for(int i = 0; i < raycastHits.Count - 1; i++)
        {
            if (Vector3.Distance(transform.position + transform.forward, raycastHits[i + 1]) < Vector3.Distance(transform.position, raycastHits[i]))
            {
                furthestPointIndex = i + 1;
            }
        }

        return raycastHits[furthestPointIndex];
    }
}
