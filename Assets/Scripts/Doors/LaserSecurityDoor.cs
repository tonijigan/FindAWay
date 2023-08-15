using UnityEngine;

public class LaserSecurityDoor : Door
{
    private void Start() => SetPositions();

    private void SetPositions()
    {
        int newPositionX = 1;
        int positionZero = 0;
        _startPositionDoor = _typeDoor.transform.position;
        _newPositionDoor = _startPositionDoor + new Vector3(newPositionX, positionZero, positionZero);
    }
}
