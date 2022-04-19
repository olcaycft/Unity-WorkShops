using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LegController : MonoBehaviour
{
   [SerializeField] private Transform rightLeg;
   [SerializeField] private Transform leftLeg;
   [SerializeField] private float footStepTimer = 0.5f;
   private Sequence stepSequence;
   private void Awake()
   {
      stepSequence = DOTween.Sequence();
      InvokeRepeating(nameof(FootStepRoutine),0f,footStepTimer*4);
   }

   private void FootStepRoutine()
   {
      stepSequence.Play();
      var positionLeftLeg = leftLeg.position;
      stepSequence.Append(leftLeg.DOMove(new Vector3(positionLeftLeg.x, positionLeftLeg.y+0.5f, positionLeftLeg.z+0.5f), footStepTimer)
         .SetEase(Ease.Linear));
      
      stepSequence.Append(leftLeg.DOMove(new Vector3(positionLeftLeg.x, positionLeftLeg.y, positionLeftLeg.z+0.5f), footStepTimer)
         .SetEase(Ease.Linear));
      leftLeg.position = positionLeftLeg;
      
      var positionRightLeg = rightLeg.position;
      stepSequence.Append(rightLeg.DOMove(new Vector3(positionRightLeg.x, positionRightLeg.y+0.5f, positionRightLeg.z+0.5f), footStepTimer)
         .SetEase(Ease.Linear));
      
      stepSequence.Append(rightLeg.DOMove(new Vector3(positionRightLeg.x, positionRightLeg.y, positionRightLeg.z+0.5f), footStepTimer)
         .SetEase(Ease.Linear));
      
      rightLeg.position = positionRightLeg;
   }
}
