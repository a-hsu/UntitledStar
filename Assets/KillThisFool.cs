using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThisFool : MonoBehaviour
{
    public GameSingleton manager;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        
    }
}
