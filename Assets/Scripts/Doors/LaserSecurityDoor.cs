using UnityEngine;

public class LaserSecurityDoor : Door
{
    protected override Vector3 SetPosition()
    {
        int newPositionX = 1;
        int positionZero = 0;
        _startPositionDoor = _typeDoor.localPosition;
        return _newPositionDoor = new Vector3(newPositionX, positionZero, positionZero);
    }
}
