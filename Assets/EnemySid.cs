using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySid : MonoBehaviour
{
    [SerializeField] public     float       speed;           // ---HOOK--- for altering movement speed during attacks/etc
                     private    bool        isMoving = true; // ---HOOK--- for turning on/off movement during attacks/etc

    [SerializeField] public     LegStepper  LegBR;
    [SerializeField] public     LegStepper  LegBL;
    [SerializeField] public     LegStepper  LegFR;
    [SerializeField] public     LegStepper  LegFL;

    private void Start()
    {
        StartCoroutine(ProceduralWalk());
    }

    private void Update()
    {
        transform.Translate(-transform.forward * speed * Time.deltaTime);
    }

    //Moves each leg one after another based on leg order in switch statement
    private IEnumerator ProceduralWalk()
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
