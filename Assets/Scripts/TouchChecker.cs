using UnityEngine;

public class TouchChecker : MonoBehaviour
{
    public UnityEventVector2 Touched;

    [SerializeField] float minSwipeDistance = 1f;

    private bool _touchStarted;

    public Vector2 touchStartPosition;
    public Vector2 touchEndPosition;

    public Vector2 currentSwipeVector;

    private Camera _camera;

    private bool _isSwipe;

    public void Init(Camera camera)
    {
        _camera = camera;

        Touched = new UnityEventVector2();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isSwipe = false;

            _touchStarted = true;
            touchStartPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_touchStarted && !_isSwipe)
            {
                Touched?.Invoke(touchStartPosition);
            }
        }
        else
        {
            if (_isSwipe || !_touchStarted)
            {
                return;
            }

            touchEndPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            currentSwipeVector = (touchEndPosition - touchStartPosition);

            if (currentSwipeVector.magnitude > minSwipeDistance)
            {
                _isSwipe = true;
            }
        }
    }
}