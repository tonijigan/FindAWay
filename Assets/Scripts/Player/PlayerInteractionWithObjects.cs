using UnityEngine;

[RequireComponent(typeof(PlayerInteractionObjectSound))]
public class PlayerInteractionWithObjects : MonoBehaviour
{
    [SerializeField] private Transform _currentTemplate;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _hitDistance;
    [SerializeField] private float _timeDelay = 0.5f;
    [SerializeField] private float _speedPassingDistance;
    [SerializeField] private float _maxDistanceFromDraggableObject;

    private PlayerInteractionObjectSound _playerInteractionObjectSound;

    private InteractionObject _draggableObject;
    private Rigidbody _rigidbodyDraggableObject;
    private bool _isDragging;
    private float _timer = 0;

    public InteractionObject DraggableObject => _draggableObject;
    public bool IsDragging => _isDragging;

    private void Start() => _playerInteractionObjectSound =
        GetComponent<PlayerInteractionObjectSound>();

    public void OnFixedUpdate() => DragAndDropObject();

    private void PickUp(InteractionObject interactionObject)
    {
        _draggableObject = interactionObject;
        _playerInteractionObjectSound.PlaySound(_draggableObject.AudioClip);
        _rigidbodyDraggableObject = _draggableObject.RigidbodyObject;
        _draggableObject.PickUp();
        _isDragging = true;
        WorkEffect(_isDragging);
    }

    private void PutDown(Transform BoxPointPosition)
    {
        if (_draggableObject.IsUse != true) return;
        _playerInteractionObjectSound.PlaySound(_draggableObject.AudioClip);
        var position = BoxPointPosition.position;
        var direction = position - _draggableObject.transform.position;
        _rigidbodyDraggableObject.velocity = direction;
        _draggableObject.PutDown();
        _draggableObject.TransformObject.position = position;
        _draggableObject = null;
        _isDragging = false;
        WorkEffect(_isDragging);
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

        if (TryGetObject(out var currentObject)) HaveDragging(currentObject);

        if (!_draggableObject && _isDragging == false) return;

        TransferringObject();
        HaveDistance();
    }

    private void HaveDistance()
    {
        var currentDistance = Vector3.Distance(_currentTemplate.position, _draggableObject.transform.position);

        if (currentDistance < _maxDistanceFromDraggableObject) return;

        _draggableObject.ActiveObject();
        _draggableObject.PutDown();
        _isDragging = false;
        WorkEffect(_isDragging);
        _draggableObject = null;
    }

    private void WorkEffect(bool isWork)
    {
        if (isWork)
            _effect.Play();
        else
            _effect.Stop();
    }

    private void TransferringObject()
    {
        var direction = _currentTemplate.position - _draggableObject.transform.position;
        _rigidbodyDraggableObject.velocity = direction * _speedPassingDistance;
    }

    private void HaveDragging(GameObject currentObject)
    {
        if (_isDragging == false)
        {
            if (currentObject.TryGetComponent(out Box box) && box.IsUse == false)
                PickUp(box);

            if (currentObject.TryGetComponent(out Key key))
                PickUp(key);
        }
        else
        {
            if (currentObject.TryGetComponent(out ButtonObject button) && button.IsClick == false)
                PutDown(button.BoxPoint);

            if (!currentObject.TryGetComponent(out DoorWithLock doorWithLock)) return;
            _isDragging = doorWithLock.TryOpenDoor(_draggableObject);

            WorkEffect(_isDragging);
        }
    }
}