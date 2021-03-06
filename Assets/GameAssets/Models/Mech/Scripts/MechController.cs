using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechController: MonoBehaviour {

	public LineRenderer BigCanon01L;
	public LineRenderer BigCanon01R;
	public LineRenderer BigCanon02L;
	public LineRenderer BigCanon02R;

	public LineRenderer SmallCanon01L;
	public LineRenderer SmallCanon01R;
	public LineRenderer SmallCanon02L;
	public LineRenderer SmallCanon02R;

	public AudioClip audioBigCanon;
	public AudioClip audioSmallCanon;

	AudioSource audioSource;
    public float shotInterval = 0.2f;

    public Transform Player;
    public MechTranslation parent;

    public Animator m_Animator;

    private Vector3 m_closestVertex;
    public bool hasTarget = false;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(AttackPlayer());
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        while (true)
        {
            Vector3 relativePos = new Vector3(Player.transform.position.x - transform.position.x, 0f, Player.transform.position.z - transform.position.z);
            Quaternion rotation = Quaternion.LookRotation(Vector3.Scale(new Vector3(0.5f, 0.5f, 0.5f), relativePos));
            rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            transform.rotation = rotation;

            if (m_Animator.GetBool("isMoving"))
            {
                parent.speed = 0.1f;
            }
            else
            {
                parent.speed = 0f;
            }
            yield return null;
        }
    }
    public GameObject body;
    public GameObject target;
    private IEnumerator AttackPlayer()
    {
        hasTarget = true;
        while (true)
        {
            //Walk for 5 seconds
            yield return new WaitForSecondsRealtime(5f);
            body.transform.LookAt(target.transform);
            //Shoot small cannons for 3 seconds
            m_Animator.SetBool("shootSmallCannon", true);
            m_Animator.SetBool("isMoving", false);
            StartCoroutine(ShootSmallCannon());
            yield return new WaitForSecondsRealtime(3f);

            //Walk for 5 more seconds
            m_Animator.SetBool("isMoving", true);
            m_Animator.SetBool("shootSmallCannon", false);
            yield return new WaitForSecondsRealtime(5f);

            //Shoot big cannons for 3 seconds
            m_Animator.SetBool("isMoving", false);
            m_Animator.SetBool("shootBigCannon", true);
            StartCoroutine(ShootBigCannon());
            yield return new WaitForSecondsRealtime(3f);

            m_Animator.SetBool("shootBigCannon", false);
            m_Animator.SetBool("isMoving", true);
        }
        
    }


	//Big Canons
    private IEnumerator ShootBigCannon()
    {
        while (m_Animator.GetBool("shootBigCannon"))
        {
            ShootBigCanonA();
            yield return new WaitForSecondsRealtime(shotInterval);
            ShootBigCanonB();
            yield return new WaitForSecondsRealtime(shotInterval);
        }
    }

	void ShootBigCanonA() {
		
		audioSource.clip = audioBigCanon;
		audioSource.Play ();

		Color c = BigCanon01L.material.GetColor ("_TintColor");
		c.a = 1f;
		BigCanon01L.material.SetColor("_TintColor",  c);
		BigCanon01R.material.SetColor("_TintColor",  c);
		StartCoroutine (FadoutBigCanon01());
	}

	IEnumerator FadoutBigCanon01() {
		Color c = BigCanon01L.material.GetColor ("_TintColor");
		while (c.a > 0) {
			c.a -= 0.1f;
			BigCanon01L.material.SetColor("_TintColor",  c);
			BigCanon01R.material.SetColor("_TintColor",  c);
			yield return null;
		}
	}

	void ShootBigCanonB() {

		audioSource.clip = audioBigCanon;
		audioSource.Play ();

		Color c = BigCanon01L.material.GetColor ("_TintColor");
		c.a = 1f;
		BigCanon02L.material.SetColor("_TintColor",  c);
		BigCanon02R.material.SetColor("_TintColor",  c);
		StartCoroutine (FadoutBigCanon02());
	}

	IEnumerator FadoutBigCanon02() {
		Color c = BigCanon02L.material.GetColor ("_TintColor");
		while (c.a > 0) {
			c.a -= 0.1f;
			BigCanon02L.material.SetColor("_TintColor",  c);
			BigCanon02R.material.SetColor("_TintColor",  c);
			yield return null;
		}
	}


    // Small Canons
    private IEnumerator ShootSmallCannon()
    {
        while (m_Animator.GetBool("shootSmallCannon"))
        {
            ShootSmallCanonA();
            yield return new WaitForSecondsRealtime(shotInterval);
            ShootSmallCanonB();
            yield return new WaitForSecondsRealtime(shotInterval);
        }
    }


    void ShootSmallCanonA() {

		audioSource.clip = audioSmallCanon;
		audioSource.Play ();

		Color c = SmallCanon01L.material.GetColor ("_TintColor");
		c.a = 1f;
		SmallCanon01L.material.SetColor("_TintColor",  c);
		SmallCanon01R.material.SetColor("_TintColor",  c);
		StartCoroutine (FadoutSmallCanon01());
	}

	IEnumerator FadoutSmallCanon01() {
		Color c = SmallCanon01L.material.GetColor ("_TintColor");
		while (c.a > 0) {
			c.a -= 0.1f;
			SmallCanon01L.material.SetColor("_TintColor",  c);
			SmallCanon01R.material.SetColor("_TintColor",  c);
			yield return null;
		}
	}

	void ShootSmallCanonB() {

		audioSource.clip = audioSmallCanon;
		audioSource.Play ();

		Color c = SmallCanon01L.material.GetColor ("_TintColor");
		c.a = 1f;
		SmallCanon02L.material.SetColor("_TintColor",  c);
		SmallCanon02R.material.SetColor("_TintColor",  c);
		StartCoroutine (FadoutSmallCanon02());
	}

	IEnumerator FadoutSmallCanon02() {
		Color c = SmallCanon02L.material.GetColor ("_TintColor");
		while (c.a > 0) {
			c.a -= 0.1f;
			SmallCanon02L.material.SetColor("_TintColor",  c);
			SmallCanon02R.material.SetColor("_TintColor",  c);
			yield return null;
		}
	}





}
