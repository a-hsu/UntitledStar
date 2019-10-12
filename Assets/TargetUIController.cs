using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetUIController : MonoBehaviour
{
    public Transform targetOne;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(targetOne.transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp(pos.y, 0,2);
        transform.position = Camera.main.ViewportToScreenPoint(pos);


        //transform.position = pos;// Camera.main.ViewportToWorldPoint(pos);
    }
}
