using UnityEngine.Events;

public abstract class TweenAnimation
{
    /// <summary>
    /// Воспроизвести DOTween анимацию
    /// </summary>
    /// <param name="Finished">Колбэк по окончанию анимации</param>
    public abstract void Play(UnityAction Finished = null);
}