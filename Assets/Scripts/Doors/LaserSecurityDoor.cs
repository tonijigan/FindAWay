using UnityEngine;

public class LaserSecurityDoor : Door
{
    protected override Vector3 SetPosition()
    {
        int newPositionX = 1;
        StartPositionDoor = _typeDoor.localPosition;
        return NewPositionDoor = Vector3.right * newPositionX;
    }
}
