using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelGoalPanel : MonoBehaviour
{
    [SerializeField] Text text;

    public void Enable(UnityAction Finished = null)
    {
        PlayAnimation(new FadeAnimation(text, 1f), Finished);
    }

    private void PlayAnimation(TweenAnimation animation, UnityAction Finished = null)
    {
        animation.Play(Finished);
    }

    public void SetGoal(string goal)
    {
        text.text = goal;
    }
}