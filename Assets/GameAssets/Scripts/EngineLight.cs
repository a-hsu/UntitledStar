﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineLight : MonoBehaviour
{
    Light light = new Light();
    public float lowRange = 16f;
    public float highRange = 18f;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = Random.Range(lowRange, highRange);
    }
}
