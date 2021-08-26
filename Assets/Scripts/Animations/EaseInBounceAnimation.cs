using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class EaseInBounceAnimation : TweenAnimation
{
    private Transform _transform;

    private float _duration;
    private float _distanceDelimiter = 10f;
    private int _stepsCount = 5;
    private float _stepDuration;

    public EaseInBounceAnimation(Transform transform, float duration = 1f)
    {
        _transform = transform;
        _duration = duration;
    }

    public override void Play(UnityAction Finished = null)
    {
        _stepDuration = _duration / _stepsCount;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_transform.DOLocalMoveX(-1.5f / _distanceDelimiter, _stepDuration));
        sequence.Append(_transform.DOLocalMoveX(1.5f / _distanceDelimiter, _stepDuration));
        sequence.Append(_transform.DOLocalMoveX(-0.25f / _distanceDelimiter, _stepDuration));
        sequence.Append(_transform.DOLocalMoveX(0.25f / _distanceDelimiter, _stepDuration));
        sequence.Append(_transform.DOLocalMoveX(0f / _distanceDelimiter, _stepDuration));

        sequence.AppendCallback(() =>
        {
            Finished?.Invoke();
        });
    }
}