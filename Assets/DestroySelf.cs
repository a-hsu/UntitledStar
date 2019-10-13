using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float time = 5f;

    private void Start()
    {
        StartCoroutine(selfdestruct());
    }
    private IEnumerator selfdestruct()
    {
        while (true)
        {
            time -= Time.deltaTime;
            if (time < 0)
                Destroy(transform.gameObject);
            yield return null;
        }
    }
}
