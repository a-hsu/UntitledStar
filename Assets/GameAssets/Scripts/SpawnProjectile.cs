﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{

    public GameObject firePointOne;
    public GameObject firePointTwo;
    public GameObject firePointThree;
    public GameObject firePointFour;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;
    PlayerInput input;
    PlayerStatus status;

    public float timeToFire = 0;
    // Start is called before the first frame update
    void Start()
    {

        effectToSpawn = vfx[0];
        input = GetComponent<PlayerInput>();
        status = new PlayerStatus();
        status.laserType = PlayerStatus.Laser.Double;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {

            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            if (status.laserType == PlayerStatus.Laser.Single)
            {
                SpawnVFX(0);
            }
            else if (status.laserType == PlayerStatus.Laser.Double)
            {
                SpawnVFX(1);
            }
        }
    }
    void SpawnVFX(float type)
    {
        GameObject vfx;
        if (type == 1)
        {
            if (firePointTwo != null)
            {
                print("Shotfired");
                vfx = Instantiate(effectToSpawn, firePointTwo.transform.position, firePointTwo.transform.rotation);

            }
            if (firePointThree != null)
            {
                print("Shotfired");
                vfx = Instantiate(effectToSpawn, firePointThree.transform.position, firePointThree.transform.rotation);


            }
            else
            {
                Debug.Log("No Fire Point");
            }
        }
    }
}
