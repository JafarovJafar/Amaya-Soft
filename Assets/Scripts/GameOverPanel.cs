using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    [SerializeField] float duration;

    public void Enable(UnityAction Finished = null)
    {
        DoFade(true, () =>
        {
            canvasGroup.blocksRaycasts = true;
            Finished?.Invoke();
        });
    }

    public void Disable(UnityAction Finished = null)
    {
        DoFade(false, () =>
        {
            canvasGroup.blocksRaycasts = false;
            Finished?.Invoke();
        });
    }

    private void DoFade(bool toWhite, UnityAction Finished)
    {
        Sequence sequence = DOTween.Sequence();

        float goalAlpha = toWhite ? 1 : 0;

        sequence.Append(canvasGroup.DOFade(goalAlpha, duration));
        sequence.AppendCallback(() => { Finished?.Invoke(); });
    }
}