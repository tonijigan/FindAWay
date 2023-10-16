using System.Collections;
using UnityEngine;

public class DoorWithLock : Door
{
    [SerializeField] private float _speedRotate = 1;

    private bool _isClose = true;

    private void Start() => SetPosition();

    public bool TryOpenDoor(InteractionObject interactionObject)
    {
        if (interactionObject == null)
            return _isClose;
        else
        {
            if (interactionObject.TryGetComponent(out Key key))
                UseKey(key);

            return _isClose;
        }
    }

    private void UseKey(Key key)
    {
        key.Enable();
        WorkDoor();
        _isClose = false;
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