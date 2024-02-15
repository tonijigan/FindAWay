using UnityEngine;

[RequireComponent(typeof(PlayerInteractionObjectSound))]
public class PlayerInteractionWithObjects : MonoBehaviour
{
    [SerializeField] private Transform _currentTemplate;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _hitDistance;
    [SerializeField] private float _timeDelay = 0.5f;

    private PlayerInteractionObjectSound _playerInteractionObjectSound;
    private InteractionObject _dragableObject;
    private bool _isDragging;
    private float _timer = 0;

    public InteractionObject DragableObject => _dragableObject;
    public bool IsDragging => _isDragging;

    private void Start() => _playerInteractionObjectSound =
        GetComponent<PlayerInteractionObjectSound>();

    public void OnFixedUpdate() => DragAndDropObject();

    private void TryPickUp(InteractionObject interactionObject)
    {
        _dragableObject = interactionObject;
        _playerInteractionObjectSound.PlaySound(_dragableObject.AudioClip);
        _dragableObject.FollowInstructions();
        _dragableObject.TransformObject.parent = default;
        _dragableObject.TransformObject.position = default;
        _dragableObject.TransformObject.SetParent(_currentTemplate.transform, false);
        _isDragging = true;
    }

    private void PutDown(Transform boxPoint)
    {
        if (_dragableObject.IsUse != true) return;
        _playerInteractionObjectSound.PlaySound(_dragableObject.AudioClip);
        _dragableObject.FollowInstructions();
        _dragableObject.TransformObject.parent = default;
        _dragableObject.TransformObject.position = boxPoint.position;
        _isDragging = false;
        _dragableObject = null;
    }

    private bool TryGetObject(out GameObject currentObject)
    {
        currentObject = null;
        var ray = new Ray(_rayPoint.position, _rayPoint.forward);

        if (Physics.Raycast(ray, out var hitInfo) && hitInfo.distance < _hitDistance)
            currentObject = hitInfo.collider.gameObject;

        return currentObject != null;
    }

    private void DragAndDropObject()
    {
        _timer += Time.deltaTime;

        if (!(_timer > _timeDelay)) return;
        _timer = 0;

        if (TryGetObject(out var currentObject))
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