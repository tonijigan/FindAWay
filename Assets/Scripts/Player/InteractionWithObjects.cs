using UnityEngine;
using UnityEngine.Events;

public class InteractionWithObjects : MonoBehaviour
{
    [SerializeField] private Transform _currentTemplate;
    [SerializeField] private float _hitDistance;
    [SerializeField] private float _beamLength;

    private Box _dragableObject;

    private Rigidbody _rigidBodyDrag;
    //public event UnityAction OnHit;

    private void Update()
    {
        _dragableObject = HaveObjectBoxForUse();
        TryPickUp();
    }

    private Box HaveObjectBoxForUse()
    {
        var ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * _beamLength, Color.green);

        if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.distance < _hitDistance)
        {
            hitInfo.collider.gameObject.TryGetComponent(out Box box);

            return box;
        }
        else
            return null;
    }

    public void TryPickUp()
    {
        if (Input.GetMouseButtonDown(0) && _dragableObject != null)
        {
            PrepareForDrag();
            Drag();
        }
    }

    private void PrepareForDrag()
    {
        _rigidBodyDrag = _dragableObject.GetComponent<Rigidbody>();
        _dragableObject.GetComponent<Box>().PrepareForDrag();
    }

    private void Drag()
    {
        Vector3 dragDirection = _currentTemplate.position - _dragableObject.transform.position;
        _rigidBodyDrag.velocity = dragDirection * 5;
    }
}
