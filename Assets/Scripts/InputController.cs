using UnityEngine;

public class InputController : MonoBehaviour
{
    private bool _isEnabled;

    [SerializeField] TouchChecker touchChecker;

    private Camera _camera;

    private readonly float _touchCheckMaxZPos = 100f;

    private Vector3 _touchDirection;

    private RaycastHit2D _raycastHit;

    public void Init(Camera camera)
    {
        _camera = camera;

        touchChecker.Init(camera);
        touchChecker.Touched.AddListener(OnTouch);

        _touchDirection = Vector3.forward * _touchCheckMaxZPos;
    }

    public void Enable()
    {
        SetEnabled(true);
    }

    public void Disable()
    {
        SetEnabled(false);
    }

    private void SetEnabled(bool enabled)
    {
        _isEnabled = enabled;
        touchChecker.enabled = enabled;
    }

    private void OnTouch(Vector2 touchPosition)
    {
        if (_isEnabled)
        {
            _raycastHit = Physics2D.Raycast(touchPosition, _touchDirection);

            if (_raycastHit.transform)
            {
                ITouchable iTouchable = _raycastHit.transform.GetComponent<ITouchable>();

                if (iTouchable != null)
                {
                    iTouchable.OnTouch();
                }
            }
        }
    }
}