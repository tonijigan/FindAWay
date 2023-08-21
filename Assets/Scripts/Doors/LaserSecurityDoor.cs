using UnityEngine;

public class LaserSecurityDoor : Door
{
    protected override Vector3 SetPosition()
    {
        int newPositionX = 1;
        int positionZero = 0;
        _startPositionDoor = _typeDoor.transform.position;
        return _newPositionDoor = _startPositionDoor + new Vector3(newPositionX, positionZero, positionZero);
    }
}
