using UnityEngine;
using UnityEngine.Events;

public class InteractionWithObjects : MonoBehaviour
{
    [SerializeField] private ButtonsDynamic _buttonsDynamic;
    [SerializeField] private Transform _currentTemplate;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _hitDistance;

    public event UnityAction HitInteractionObject, HitButton;

    private InteractionObject _dragableObject;
    private bool _isDragging;

    public InteractionObject DragableObject => _dragableObject;
    public bool IsDragging => _isDragging;

    private void Awake() => _buttonsDynamic.gameObject.SetActive(false);

    private void Update() => DragAndDropObject();

    public void ChangeIsDragging() => _isDragging = false;

    public void TryPickUp(InteractionObject interactionObject)
    {
        _dragableObject = interactionObject;
        _dragableObject.FollowInstructions();
        _dragableObject.transform.parent = default;
        _dragableObject.transform.position = default;
        _dragableObject.transform.SetParent(_currentTemplate.transform, false);
        _isDragging = true;
    }

    public void PutDown(Transform boxPoint)
    {
        _dragableObject.FollowInstructions();
        _dragableObject.transform.parent = default;
        _dragableObject.transform.position = boxPoint.position;
        _isDragging = false;
    }

    private bool TryGetObject(out GameObject currentObject)
    {
        currentObject = null;
        var ray = new Ray(_rayPoint.position, _rayPoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.distance < _hitDistance)
            currentObject = hitInfo.collider.gameObject;

        return currentObject != null;
    }

    private void DragAndDropObject()
    {
        if (TryGetObject(out GameObject currentObject))
        {
            if (_isDragging == false && currentObject.TryGetComponent(out Key key))
                EnableButtonDynamic(currentObject);
            if (_isDragging == false && currentObject.TryGetComponent(out Box box))
                EnableButtonDynamic(currentObject);
            if (_isDragging == true && currentObject.TryGetComponent(out ButtonObject button)
               && button.IsClick != true)
                EnableButtonDynamic(currentObject);
        }
        else
        {
            DisableButtonDynamic();
        }
    }

    private void EnableButtonDynamic(GameObject currentObject)
    {
        _buttonsDynamic.gameObject.SetActive(true);
        _buttonsDynamic.Init(currentObject);

        if (_isDragging == false)
            HitInteractionObject?.Invoke();
        else
            HitButton?.Invoke();
    }

    private void DisableButtonDynamic() => _buttonsDynamic.DisableButtons();
}