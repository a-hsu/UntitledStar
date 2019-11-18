using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AnimController : MonoBehaviour
{
    [SerializeField] public     Transform   target;
    [Range(0.0f, 50f)] public  float       moveSpeed;           // ---HOOK--- for altering movement speed during attacks/etc
    [Range(0.0f, 0.3f)] public  float       turnSpeed;           // ---HOOK--- "" turn speed ""
    [SerializeField] public     float       fieldOfViewAngles;   // ---HOOK--- for changing how much rig will rotate before moving toward target
                     public     bool        isMoving = true;     // ---HOOK--- for turning on/off movement during attacks/etc

    [SerializeField] public BodyMovement Root;
    [SerializeField] public     LegStepper  LegBR;
    [SerializeField] public     LegStepper  LegBL;
    [SerializeField] public     LegStepper  LegFR;
    [SerializeField] public     LegStepper  LegFL;

    private void Start()
    {
        //Assuming there is always a target (for this boss fight) we're always moving
        StartCoroutine(RootMotion());
        StartCoroutine(ProceduralWalk());
    }

    public IEnumerator RootMotion()
    {
        //Translate
        
        while ( Vector3.Distance(target.position, transform.position) > 10f && isMoving)
        {
            Vector3 targetDir = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, target.position.z - transform.position.z);

            // Translate only after turning toward target
            if (Vector3.Angle(transform.forward, targetDir) < fieldOfViewAngles)
            {
                transform.Translate(Vector3.Normalize(targetDir) * moveSpeed * Time.deltaTime, Space.World);
            }

            //Rotate
            //if (Mathf.Abs(targetDir.x) > 200 && Mathf.Abs(targetDir.z) > 200)
            //{
            //    targetDir = targetDir + new Vector3(0, target.position.y / 30f);
            //}
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, turnSpeed, 0.0f);
            Debug.DrawRay(transform.position, newDir * 200f, Color.red);
            Quaternion rot = Quaternion.LookRotation(newDir);
            rot = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
            transform.rotation = rot;

            yield return null;
        }
    }

    //Moves each leg one after another based on leg order in switch statement
    public IEnumerator ProceduralWalk()
    {
        while (isMoving)
        {
            //Leg movement here is order-sensitive
            do
            {
                LegFR.TryTakeStep();
                yield return null;
            } while (LegFR.isMoving);

            do
            {
                LegBL.TryTakeStep();
                yield return null;
            } while (LegBL.isMoving);

            do
            {
                LegFL.TryTakeStep();
                yield return null;
            } while (LegFL.isMoving);

            do
            {
                LegBR.TryTakeStep();
                yield return null;
            } while (LegBR.isMoving);
        }
    }

}
