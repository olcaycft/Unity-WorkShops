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
   private Sequence stepSequence;
   [SerializeField] private List<Transform> pointList = new List<Transform>();

   [SerializeField] private Animator animator;
   private static readonly int LeftFootReach = Animator.StringToHash("LeftFootReach");

   private void Awake()
   {
      stepSequence = DOTween.Sequence();
      //InvokeRepeating(nameof(FootStepRoutine),0f,footStepTimer*4);
      //FootStepRoutine();
      //StartCoroutine(FootStepRoutine());
      //OnAnimatorIK();
      /*for (int i = 0; i < pointList.Count; i+=2)
      {
         FootStepRoutine(pointList[i],pointList[i+1]);
      }*/
      
      /*for(int i = 0; i < pointList.Count; i+=2)
      {
         //Thread.Sleep(2000);
         //FootStepRoutine(pointList[i],pointList[i+1]);
         
      }*/
      StartCoroutine(FootStepRoutine());
   }

   private IEnumerator FootStepRoutine()
   {
      for (int i = 0; i < pointList.Count; i+=2)
      {
         var currentLeftFootTarget = pointList[i].position;
         var currentRightFootTarget = pointList[i+1].position;

         currentLeftFootTarget.y += 0.5f;
         //currentLeftFootTarget.z += 0.5f;
         leftLeg.DOMove(new Vector3(currentLeftFootTarget.x,currentLeftFootTarget.y,(currentLeftFootTarget.z-leftLeg.position.z)/2), 0.5f).SetEase(Ease.Linear);
         yield return new WaitForSeconds(0.5f);
         
         currentLeftFootTarget.y -= 0.5f;
         //currentLeftFootTarget.z += 0.5f;
         leftLeg.DOMove(new Vector3(currentLeftFootTarget.x,currentLeftFootTarget.y,currentLeftFootTarget.z), 0.5f).SetEase(Ease.Linear);
         leftLeg.position = currentLeftFootTarget;
         yield return new WaitForSeconds(0.5f);
         
         currentRightFootTarget.y += 0.5f;
         //currentRightFootTarget.z += 0.5f;
         rightLeg.DOMove(new Vector3(currentRightFootTarget.x,currentRightFootTarget.y,(currentRightFootTarget.z-rightLeg.position.z)/2), 0.5f).SetEase(Ease.Linear);
         yield return new WaitForSeconds(0.5f);
         
         currentRightFootTarget.y -= 0.5f;
         //currentRightFootTarget.z += 0.5f;
         rightLeg.DOMove(new Vector3(currentRightFootTarget.x,currentRightFootTarget.y,currentRightFootTarget.z), 0.5f).SetEase(Ease.Linear);
         rightLeg.position = currentRightFootTarget;
         yield return new WaitForSeconds(0.5f);
         
      }
      
      
      
        // stepSequence.Play();
         //var positionLeftLeg = leftLeg.position;
         /*stepSequence.Append(leftLeg.DOMove(leftTarger.position, 0f)
            .SetEase(Ease.Linear));*/
         
         /*stepSequence.Append(leftLeg.DOMove(new Vector3(positionLeftLeg.x, positionLeftLeg.y, positionLeftLeg.z+0.5f), footStepTimer)
            .SetEase(Ease.Linear));
         leftLeg.position += positionLeftLeg;*/
      
         //var positionRightLeg = rightLeg.position;
         /*stepSequence.Append(rightLeg.DOMove(rightTarger.position,0f)
            .SetEase(Ease.Linear));*/
         

         /*stepSequence.Append(rightLeg.DOMove(new Vector3(positionRightLeg.x, positionRightLeg.y, positionRightLeg.z+0.5f), footStepTimer)
            .SetEase(Ease.Linear));*/

         //rightLeg.position += positionRightLeg;


         //stepSequence.SetLoops(-1, LoopType.Restart);
   }

   private void OnAnimatorIK()
   {
      var reach = animator.GetFloat(LeftFootReach);
      animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
      
      var positionLeftLeg = leftLeg.position;
      positionLeftLeg.x += 1f;
      
      animator.SetIKPosition(AvatarIKGoal.LeftFoot, positionLeftLeg);
   }
}
