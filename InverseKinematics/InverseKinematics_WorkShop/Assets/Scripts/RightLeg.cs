using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RightLeg : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float footStepTimer = 1f;
    void Start()
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
