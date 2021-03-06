using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class BounceHideAnimation : TweenAnimation
{
    private Transform _transform;

    private float _firstStepScale = 2f;
    private float _secondStepScale = 0.5f;
    
    private float _duration;
    private int _stepsCount = 3;
    
    public BounceHideAnimation(Transform transform, float duration = 0.45f)
    {
        _transform = transform;
        _duration = duration;
    }

    public override void Play(UnityAction Finished = null)
    {
        float stepDuration = _duration / _stepsCount;
        
        _transform.localScale = Vector3.one;

        Sequence sequence = DOTween.Sequence();
        
        sequence.Append(_transform.DOScale(Vector3.one * _secondStepScale, stepDuration));
        sequence.Append(_transform.DOScale(Vector3.one * _firstStepScale, stepDuration));
        sequence.Append(_transform.DOScale(Vector3.zero, stepDuration));

        sequence.AppendCallback(()=>
        {
            Finished?.Invoke();
        });
    }
}