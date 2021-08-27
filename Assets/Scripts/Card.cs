using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour, ITouchable
{
    [SerializeField] SpriteRenderer spriteRenderer;
    
    [SerializeField] Transform spriteTransform;
    
    public UnityEvent Touched;

    private CardData _cardData;

    private bool _isAnimating;
    
    public void Init(CardData cardData)
    {
        Touched = new UnityEvent();

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
        _isAnimating = true;
        animation.Play(()=>
        {
            _isAnimating = false;
            Finished?.Invoke();
        });
    }

    public void OnTouch()
    {
        if (!_isAnimating)
        {
            Touched?.Invoke();
        }
    }
}