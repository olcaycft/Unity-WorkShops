using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using DG.Tweening;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class LegController : MonoBehaviour
{
    [SerializeField] private Transform rightLeg;
    [SerializeField] private Transform leftLeg;
    [SerializeField] private float footStepTimer = 0.5f;
    [SerializeField] private List<Transform> pointList = new List<Transform>();


    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Vector3 curveOffSet;
    [SerializeField] private float timer;

    [SerializeField] private bool isLeftStep = true;
    [SerializeField] private bool isRightStep;
    [SerializeField] private int index;
    private bool isOneStepComplete;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > footStepTimer && isOneStepComplete)
        {
            isOneStepComplete = false;
            timer = footStepTimer;
            index++;
            isRightStep = !isRightStep;
            isLeftStep = !isLeftStep;
            timer = 0;
        }
        else
        {
            if (isLeftStep) LeftFootStep();
            if (isRightStep) RightFootStep();
        }
        
        
    }

    private void LeftFootStep()
    {
        var lerpRatio = timer / footStepTimer;
        var positionOffset = curve.Evaluate(lerpRatio) * curveOffSet;
        leftLeg.position = Vector3.Lerp(pointList[index].position, pointList[index + 2].position, lerpRatio) +
                           positionOffset;

        if (index + 2 < pointList.Count-1 && !isOneStepComplete)
        {
            isOneStepComplete = true;
        }
    }

    private void RightFootStep()
    {
        
        var lerpRatio = timer / footStepTimer;
        var positionOffset = curve.Evaluate(lerpRatio) * curveOffSet;
        rightLeg.position = Vector3.Lerp(pointList[index].position, pointList[index + 2].position, lerpRatio) +
                            positionOffset;

        if (index + 2 < pointList.Count-1 && !isOneStepComplete)
        {
            isOneStepComplete = true;
        }
    }

    

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        for (int i = 0; i < pointList.Count; i++)
        {
            if (i%2==0)
            {
                Gizmos.color = Color.yellow;
            }
            else
            {
                Gizmos.color = Color.red;
            }
            
            Gizmos.DrawSphere(pointList[i].position, 0.2f);
        }
        
    }
    
}