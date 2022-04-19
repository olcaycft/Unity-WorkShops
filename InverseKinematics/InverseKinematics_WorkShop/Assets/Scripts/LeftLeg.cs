using System;
using DG.Tweening;
using UnityEngine;

public class LeftLeg : MonoBehaviour
{
    [SerializeField] private float footStepTimer = 1f;

    private void Awake()
    {
        DOTween.To(() => transform.localPosition,
                x => transform.localPosition = x, new Vector3(0f, .5f, 0.5f), footStepTimer)
            .SetEase(Ease.Linear).OnComplete(
                () =>
                {
                    transform.DOLocalMove(new Vector3(0f, 0f, transform.position.z + 0.5f), footStepTimer)
                        .SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
                }
            );
    }
}