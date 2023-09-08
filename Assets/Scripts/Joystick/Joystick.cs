using UnityEngine;
using UnityEngine.EventSystems;

public enum AxisOptions { Both, Horizontal, Vertical }

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] protected RectTransform Background = null;
    [SerializeField] private float _handleRange = 1;
    [SerializeField] private float _deadZone = 0;
    [SerializeField] private AxisOptions _axisOptions = AxisOptions.Both;
    [SerializeField] private bool _snapX = false;
    [SerializeField] private bool _snapY = false;
    [SerializeField] private RectTransform _handle = null;

    public float Horizontal { get { return (_snapX) ? SnapFloat(_input.x, AxisOptions.Horizontal) : _input.x; } }
    public float Vertical { get { return (_snapY) ? SnapFloat(_input.y, AxisOptions.Vertical) : _input.y; } }
    public float HandleRange { get { return _handleRange; } set { _handleRange = Mathf.Abs(value); } }
    public float DeadZone { get { return _deadZone; } set { _deadZone = Mathf.Abs(value); } }
    public AxisOptions AxisOptions { get { return AxisOptions; } set { _axisOptions = value; } }
    public Vector2 Direction { get { return new Vector2(Horizontal, Vertical); } }
    public bool SnapX { get { return _snapX; } set { _snapX = value; } }
    public bool SnapY { get { return _snapY; } set { _snapY = value; } }

    private RectTransform _baseRect = null;
    private Canvas _canvas;
    private Camera _cam;
    private Vector2 _input = Vector2.zero;
    private int _minValue = 0, _maxValue = 1;

    protected virtual void Start()
    {
        HandleRange = _handleRange;
        DeadZone = _deadZone;
        _baseRect = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        float centerObject = 0.5f;
        Vector2 center = new Vector2(centerObject, centerObject);
        Background.pivot = center;
        _handle.anchorMin = center;
        _handle.anchorMax = center;
        _handle.pivot = center;
        _handle.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _cam = null;
        if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
            _cam = _canvas.worldCamera;

        int divider = 2;
        Vector2 position = RectTransformUtility.WorldToScreenPoint(_cam, Background.position);
        Vector2 radius = Background.sizeDelta / divider;
        _input = (eventData.position - position) / (radius * _canvas.scaleFactor);
        FormatInput();
        HandleInput(_input.magnitude, _input.normalized, radius, _cam);
        _handle.anchoredPosition = _input * radius * _handleRange;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _input = Vector2.zero;
        _handle.anchoredPosition = Vector2.zero;
    }

    protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
    {
        Vector2 localPoint = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_baseRect, screenPosition, _cam, out localPoint))
        {
            Vector2 pivotOffset = _baseRect.pivot * _baseRect.sizeDelta;
            return localPoint - (Background.anchorMax * _baseRect.sizeDelta) + pivotOffset;
        }
        return Vector2.zero;
    }

    protected virtual void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        int acceptableZone = 1;

        if (magnitude > _deadZone)
        {
            if (magnitude > acceptableZone)
                _input = normalised;
        }
        else
            _input = Vector2.zero;
    }

    private void FormatInput()
    {
        float positionZero = 0;

        if (_axisOptions == AxisOptions.Horizontal)
            _input = new Vector2(_input.x, positionZero);
        else if (_axisOptions == AxisOptions.Vertical)
            _input = new Vector2(positionZero, _input.y);
    }

    private float SnapFloat(float value, AxisOptions snapAxis)
    {
        float minAcceptableHorizontalAngle = 22.5f;
        float minAcceptableVerticalAngle = 67.5f;
        float maxAcceptableHorizontalAngle = 157.5f;
        float maxAcceptableVerticalAngle = 112.5f;

        if (value == _minValue)
            return value;

        if (_axisOptions == AxisOptions.Both)
        {
            float angle = Vector2.Angle(_input, Vector2.up);
            if (snapAxis == AxisOptions.Horizontal)
                HaveAcceptableAngleValue(angle, value, minAcceptableHorizontalAngle, maxAcceptableHorizontalAngle);
            else if (snapAxis == AxisOptions.Vertical)
                HaveAcceptableAngleValue(angle, value, minAcceptableVerticalAngle, maxAcceptableVerticalAngle);
            return value;
        }
        else
        {
            GetValue(value);
        }
        return _minValue;
    }

    private float GetValue(float value)
    {
        if (value > _minValue)
            return _maxValue;
        else
            return -_maxValue;
    }

    private float HaveAcceptableAngleValue(float angle, float value, float minAcceptableAngle, float maxAcceptableAngle)
    {
        if (angle < minAcceptableAngle || angle > maxAcceptableAngle)
            return _minValue;
        else
            return (value > _minValue) ? _maxValue : -_maxValue;
    }
}