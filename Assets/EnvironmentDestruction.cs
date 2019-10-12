using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDestruction: MonoBehaviour
{
    [SerializeField] public Transform Ground;

    private void Update()
    {
        if (!Ground.GetComponent<Rigidbody>().isKinematic)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
