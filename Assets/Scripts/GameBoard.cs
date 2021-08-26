using UnityEngine;
using UnityEngine.Events;

public class GameBoard : MonoBehaviour
{
    public UnityEvent Updated;

    public void Enable()
    {
        PlayAnimation(new BounceAnimation(transform), () =>
        {
            Updated?.Invoke();
        });
    }

    public void Disable()
    {
        PlayAnimation(new BounceHideAnimation(transform), () =>
        {
            Updated?.Invoke();
        });
    }

    private void PlayAnimation(TweenAnimation animation, UnityAction Finished = null)
    {
        animation.Play(Finished);
    }
}