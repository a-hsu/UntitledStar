using System.Collections;
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
    public AudioManager audio;
    PlayerStatus status;
    
    float timer = 0;

    public float timeToFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
        input = GetComponent<PlayerInput>();
        status = new PlayerStatus();
        status.laserType = PlayerStatus.Laser.Double;
    }

    private IEnumerator ShootMissile()
    {
        yield return new WaitForSeconds(.5f);
        SpawnVFX(2);
    }
        // Update is called once per frame
        void Update()
    {
        if(gameObject.name == "Mech")
        {
            timer += Time.deltaTime;
            if(timer > 5f)
            {
                StartCoroutine(ShootMissile());
                StartCoroutine(ShootMissile());
                StartCoroutine(ShootMissile());
                timer = 0;
            }
        }else if (Input.GetButton("Fire1") && Time.time >= timeToFire)
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
    public AudioClip singleLaser;
    void SpawnVFX(float type)
    {
        GameObject vfx;
        if (type == 1)
        {
            if (firePointTwo != null)
            {
                print("Shotfired");
                vfx = Instantiate(effectToSpawn, firePointTwo.transform.position, firePointTwo.transform.rotation);
               // audio.Play(singleLaser);
                

            }
            if (firePointThree != null)
            {
                print("Shotfired");
                vfx = Instantiate(effectToSpawn, firePointThree.transform.position, firePointThree.transform.rotation);
                //audio.Play(singleLaser);

            }
            else
            {
                Debug.Log("No Fire Point");
            }
        }
        if (type == 2)
        {
            vfx = Instantiate(effectToSpawn, firePointTwo.transform.position, firePointTwo.transform.rotation);
        }
    }
}
