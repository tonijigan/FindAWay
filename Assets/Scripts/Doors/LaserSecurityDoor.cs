using UnityEngine;

public class LaserSecurityDoor : Door
{
    protected override Vector3 SetPosition()
    {
        int newPositionX = 1;
        _startPositionDoor = _typeDoor.localPosition;
        return _newPositionDoor = Vector3.right * newPositionX;
    }
}
