using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour, ITouchable
{
    [SerializeField] SpriteRenderer spriteRenderer;
    
    [SerializeField] Transform spriteTransform;
    
    public UnityEvent Touched;
    public UnityEvent AnimationFinished;

    private CardData _cardData;

    public void Init(CardData cardData)
    {
        Touched = new UnityEvent();
        AnimationFinished = new UnityEvent();

        _cardData = cardData;
        spriteRenderer.sprite = cardData.Sprite;
    }

    public void BehaveCorrect(UnityAction Finished = null)
    {
        PlayAnimation(new BounceAnimation(spriteTransform), Finished);
    }

    public void BehaveIncorrect(UnityAction Finished = null)
    {
        PlayAnimation(new EaseInBounceAnimation(spriteTransform), Finished);
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