using System;
using DG.Tweening;
using UnityEngine;

public class MopArrowMoverView : MonoBehaviour
{
    [SerializeField] private float _topPosition = 5f;
    [SerializeField] private float _duration = 2f;

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        transform.DOMoveY(_topPosition, _duration)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }
}