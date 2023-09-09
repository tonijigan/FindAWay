using System.Collections;
using UnityEngine;

public class DoorWithLock : Door
{
    [SerializeField] private float _speedRotate = 1;

    private void Start() => SetPosition();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractionWithObjects interactionWithObjects)
            && interactionWithObjects.DragableObject != null)
        {
            if (interactionWithObjects.DragableObject.TryGetComponent(out Key key))
            {
                key.Destroy();
                interactionWithObjects.ChangeIsDragging();
                WorkDoor();
            }
        }
    }

    public override IEnumerator MoveDoor(Vector3 newxTarget)
    {
        IsOpenDoor = !IsOpenDoor;

        while (_typeDoor.localRotation != Quaternion.Euler(newxTarget))
        {
            _typeDoor.localRotation = Quaternion.Lerp(_typeDoor.localRotation, Quaternion.Euler(newxTarget), _speedRotate * Time.deltaTime);
            yield return null;
        }

        StopCoroutine(Coroutine);
    }

    protected override void SetPosition()
    {
        float rotateInPositionZero = 0;
        float rotatePositionY = -90;
        StartPositionDoor = _typeDoor.localPosition;
        NewPositionDoor = new Vector3(rotateInPositionZero, rotatePositionY, rotateInPositionZero);
    }
}