using UnityEngine;
using UnityEngine.Events;

public class InteractionWithObjects : MonoBehaviour
{
    [SerializeField] private Transform _currentTemplate;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _hitDistance;

    private GameObject _dragableObject;
    private bool _isDragging;

    //public event UnityAction OnHitBox, OnHitButton;

    private void Update()
    {
        DragAndDropObject();
    }

    private bool TryGetGameCollider(out Collider currentCollider)
    {
        currentCollider = null;
        var ray = new Ray(_rayPoint.position, _rayPoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.distance < _hitDistance)
            currentCollider = hitInfo.collider;

        return currentCollider != null;
    }

    private void DragAndDropObject()
    {
        if (TryGetGameCollider(out Collider currentCollider))
        {
            if (_isDragging == false && currentCollider.gameObject.TryGetComponent(out Box box))
                TryPickUp(box); //OnHitBox?.Invoke();

            if (_isDragging == true && currentCollider.gameObject.TryGetComponent(out Button button))
                PutDown(button.BoxPoint); //OnHitButton?.Invoke();
        }
    }


    public void TryPickUp(Box box)
    {
        if (Input.GetMouseButtonDown(1))
        {
            _dragableObject = box.gameObject;
            _dragableObject.transform.position = default;
            _dragableObject.transform.SetParent(_currentTemplate.transform, false);
            _isDragging = true;
        }
    }

    public void PutDown(Transform boxPoint)
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragableObject.transform.parent = default;
            _dragableObject.transform.position = boxPoint.position;
            _isDragging = false;
        }
    }
}
