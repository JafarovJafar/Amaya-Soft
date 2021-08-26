using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour, ITouchable
{
    [SerializeField] Sprite _cardSprite;

    public UnityEvent Touched;
    public UnityEvent AnimationFinished;

    private CardData _cardData;

    public void Init(CardData cardData)
    {
        Touched = new UnityEvent();
        AnimationFinished = new UnityEvent();

        _cardData = cardData;
        _cardSprite = _cardData.Sprite;
    }

    public void BehaveCorrect(UnityAction Finished = null)
    {
        PlayAnimation(new BounceAnimation(transform), Finished);
    }

    private void PlayAnimation(TweenAnimation animation, UnityAction Finished)
    {
        animation.Play(Finished);
    }

    public void OnTouch()
    {
        Touched?.Invoke();
    }
}