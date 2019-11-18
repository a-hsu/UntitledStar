using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyChecker : MonoBehaviour
{
    public Transform target;
    public Transform parentMech;
    private float checkDistance = 150f;
    public List<Vector3> lastPositions;
    public bool isOnWall = true;
    List<Vector3> raycastHits = new List<Vector3>();


    private void Start()
    {
        Physics.IgnoreLayerCollision(9, 9);
        
    }
    private void Update()
    {

        if (lastPositions.Count > 15)
            lastPositions.RemoveAt(0);

        if (Vector3.Distance(transform.position, parentMech.position) < 100f && Vector3.Distance(transform.position, target.position) > 50f)
            transform.position = SetNextStepPosition();

    }
    public Vector3 SetNextStepPosition()
    {


        raycastHits.Clear();
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

        RaycastHit hit;

        //down
        if (Physics.Raycast(transform.position, -transform.up, out hit, checkDistance + 25f))
            raycastHits.Add(hit.point);

        //forward + down
        if (Physics.Raycast(transform.position, -transform.up + transform.forward, out hit, checkDistance))
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

        List<Vector3> tempArray = new List<Vector3>();
        foreach(Vector3 pos in lastPositions)
        {
            foreach(Vector3 hits in raycastHits)
            {
                if (Vector3.Cross(pos, hits).magnitude  < 0.1f || Vector3.Distance(pos, hits) < 40f)
                    tempArray.Add(hits);
            }
        }

        foreach(Vector3 bad in tempArray)
        {
            raycastHits.Remove(bad);
        }

        int furthestPointIndex = 0;
        for (int i = 0; i < raycastHits.Count; i++)
        {
            if (Vector3.Distance(target.position, raycastHits[i]) < Vector3.Distance(target.position, transform.position))
            {
                furthestPointIndex = i;
            }
        }
        if (raycastHits.Count > 0)
        {
            isOnWall = true;
            lastPositions.Add(raycastHits[furthestPointIndex]);
            Debug.Log(raycastHits[furthestPointIndex]);
            foreach(Vector3 pos in lastPositions)
            {
                Debug.Log(pos);
            }
            return raycastHits[furthestPointIndex];
        }
        else
        {
            isOnWall = false;
            lastPositions.Add(transform.position + (target.position - transform.position) * Time.deltaTime * 10f);
            return transform.position + (target.position - transform.position)*Time.deltaTime*10f;
        }


    }
}
