using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeAnimation : TweenAnimation
{
    private Graphic _graphic;
    private float _finishValue;
    private float _duration;

    public FadeAnimation(Graphic graphic, float finishValue, float duration = 1f)
    {
        _graphic = graphic;
        _finishValue = finishValue;
        _duration = duration;
    }

    public override void Play(UnityAction Finished = null)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_graphic.DOFade(_finishValue, _duration));
        sequence.AppendCallback(() =>
        {
            Finished?.Invoke();
        });
    }
}