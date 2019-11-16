using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValidPositions : MonoBehaviour
{
    private void Start()
    {
        Physics.IgnoreLayerCollision(9, 9);
    }

    public Vector3 SetNextStepPosition()
    {
        RaycastHit hit;
        Vector3 newPosition = Vector3.zero;
        
        Debug.DrawRay(transform.position, -Vector3.up * 50f, Color.red, 3f);
        //note: leg bone transforms will always have weird original rotations so this is one of them
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 50f))
        {
            return hit.point;
        }
        else
        {
            return transform.position - transform.up * 30f;
        }

    }
}
