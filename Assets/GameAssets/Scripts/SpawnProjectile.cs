using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{

    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;
    PlayerInput input;
    PlayerStatus status;
    
    public float  timeToFire = 0;
     // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
        input = GetComponent<PlayerInput>();
        status = new PlayerStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            Debug.Log(Input.anyKeyDown);
        }
        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            if (status.laserType == PlayerStatus.Laser.Single)
            {
                SpawnVFX();
            } else if(status.laserType == PlayerStatus.Laser.Double)
            {
                firePoint.transform.position = this.transform.GetChild(0).position;
                SpawnVFX();
                firePoint.transform.position = this.transform.GetChild(1).position;
                SpawnVFX();
            }        
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            print("Shotfired");
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, this.transform.GetChild(0).rotation);
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
