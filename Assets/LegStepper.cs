using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class LegStepper : MonoBehaviour
{
    private Vector3 originalLocalPos;
    private Quaternion originalLocalRot;

    //private Transform constrainedBone;
    public Transform DampBone;
    public StepChecker StepChecker;

    private Vector3 stepPosition;

    public float stepDistance;
    public float stepHeight;
    public float stepDuration;

    public bool isMoving;

    private void Awake()
    {
        Physics.IgnoreLayerCollision(9,9);

        originalLocalPos = transform.localPosition;
        originalLocalRot = transform.localRotation;

        //constrainedBone = GetComponent<DampedTransform>().data.constrainedObject;

        stepPosition = transform.position;
    }

    public void TryTakeStep()
    {
        //Update target step position before checking if leg should actually move
        Vector3 possiblePosition = StepChecker.SetNextStepPosition();
        DampBone.transform.position = Vector3.Distance(possiblePosition, DampBone.transform.position) < 200 ? possiblePosition : DampBone.transform.position;


        if (Vector3.Distance(transform.position, DampBone.transform.position) > stepDistance && !isMoving)
        {
            StopCoroutine(StepToHome());
            StartCoroutine(StepToHome());
        }
    }

    public IEnumerator StepToHome()
    {
        isMoving = true;

        float timeElapsed = 0;

        Vector3 centerPoint;
        Vector3 endPoint;

        while (timeElapsed < stepDuration)
        {
            endPoint = DampBone.transform.position;
            centerPoint = new Vector3(transform.position.x, stepHeight, transform.position.z);
            timeElapsed += Time.deltaTime;
            float normalizedTime = timeElapsed / stepDuration;
            normalizedTime = EaseInOut_Cubic(normalizedTime);
            
            DampBone.GetComponent<DampedTransform>().data.dampPosition = Mathf.Clamp(Mathf.Lerp(DampBone.GetComponent<DampedTransform>().data.dampPosition, 0, normalizedTime), 0, 1f);
            
            transform.position = Vector3.Lerp(Vector3.Lerp(transform.position, centerPoint, normalizedTime),
                                                Vector3.Lerp(centerPoint, endPoint, normalizedTime),
                                                normalizedTime);

            yield return null;
        }

        DampBone.GetComponent<DampedTransform>().data.dampPosition = 1f;
        

        isMoving = false;
    }

    public float EaseInOut_Cubic(float value)
    {
        if ((value *= 2f) < 1f) return 0.5f * value * value * value;
        return 0.5f * ((value -= 2f) * value * value + 2f);
    }
}
