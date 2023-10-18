using UnityEngine;

public class InteractionWithObjects : MonoBehaviour
{
    [SerializeField] private Transform _currentTemplate;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _hitDistance;

    private InteractionObject _dragableObject;
    private bool _isDragging;

    public InteractionObject DragableObject => _dragableObject;
    public bool IsDragging => _isDragging;

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
        if (_dragableObject.IsUse == true)
        {
            _dragableObject.FollowInstructions();
            _dragableObject.transform.parent = default;
            _dragableObject.transform.position = boxPoint.position;
            _isDragging = false;
            _dragableObject = null;
        }
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
            HaveDragging(currentObject);
    }

    private void HaveDragging(GameObject currentObject)
    {
        if (_isDragging == false)
        {
            if (currentObject.TryGetComponent(out Box box) && box.IsUse == false)
                TryPickUp(box);

            if (currentObject.TryGetComponent(out Key key))
                TryPickUp(key);
        }
        else
        {
            if (currentObject.TryGetComponent(out ButtonObject button) && button.IsClick == false)
                PutDown(button.BoxPoint);

            if (currentObject.TryGetComponent(out DoorWithLock doorWithLock))
                _isDragging = doorWithLock.TryOpenDoor(_dragableObject);
        }
    }
}