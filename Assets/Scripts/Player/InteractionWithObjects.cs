using UnityEngine;
using UnityEngine.Events;

public class InteractionWithObjects : MonoBehaviour
{
    [SerializeField] private ButtonsDynamic _buttonsDynamic;
    [SerializeField] private Transform _currentTemplate;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _hitDistance;

    public event UnityAction OnHitBox, OnHitButton;

    private Box _dragableObject;
    private bool _isDragging;

    public bool IsDragging => _isDragging;

    private void Awake() => _buttonsDynamic.gameObject.SetActive(false);

    private void Update() => DragAndDropObject();

    private bool TryGetGameCollider(out Transform currentTransform)
    {
        currentTransform = null;
        var ray = new Ray(_rayPoint.position, _rayPoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.distance < _hitDistance)
            currentTransform = hitInfo.collider.transform;

        return currentTransform != null;
    }

    private void DragAndDropObject()
    {
        if (TryGetGameCollider(out Transform currentTransform))
        {
            if (_isDragging == false && currentTransform.TryGetComponent(out Box box))
                EnableButtonDynamic(currentTransform);

            if (_isDragging == true && currentTransform.TryGetComponent(out ButtonObject button))
                EnableButtonDynamic(currentTransform);
        }
        else
        {
            DisableButtonDynamic();
        }
    }

    private void EnableButtonDynamic(Transform currentTransform)
    {
        _buttonsDynamic.gameObject.SetActive(true);
        _buttonsDynamic.Init(currentTransform);

        if (_isDragging == false)
            OnHitBox?.Invoke();
        else
            OnHitButton?.Invoke();
    }

    private void DisableButtonDynamic() => _buttonsDynamic.DisableButtons();

    public void TryPickUp(Box box)
    {
        _dragableObject = box;
        _dragableObject.transform.position = default;
        _dragableObject.transform.SetParent(_currentTemplate.transform, false);
        _isDragging = true;
    }

    public void PutDown(Transform boxPoint)
    {
        _dragableObject.DisableKinematic();
        _dragableObject.transform.parent = default;
        _dragableObject.transform.position = boxPoint.position;
        _isDragging = false;
    }
}
