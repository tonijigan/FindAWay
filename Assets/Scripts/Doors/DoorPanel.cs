using UnityEngine;

public class DoorPanel : AbstractDoor
{
    protected override void SetPosition()
    {
        int newPositionX = 1;
        StartPositionDoor = _typeDoor.localPosition;
        NewPositionDoor = Vector3.right * newPositionX;
    }
}